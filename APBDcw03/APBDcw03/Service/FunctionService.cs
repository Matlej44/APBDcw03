using System.Reflection;
using System.Reflection.Metadata;
using APBDcw03.Hardwares;
using APBDcw03.Users;

namespace APBDcw03.Service;

public static class FunctionService
{
    public static void AddUser()
    {
        Console.WriteLine("Type your user(name,surname): ");
        var user = Console.ReadLine()?.Split(",");
        if(user.Length<2) return;
        Console.WriteLine("Select your user type: ");
        var count = 1;
        foreach (var item in Enum.GetNames(typeof(UserType)))
        {
            Console.WriteLine($"\t{count++}." + item);
        }

        var userType = int.Parse(Console.ReadLine() ?? string.Empty);
        var type = (UserType)userType;
        if (user == null) return;
        if (user.Length != 2) return;
        var newUser = new User(user[0], user[1], type);
        Storage.Users.Add(newUser);
        Console.WriteLine($"Your user id is: {newUser.Id}. Press any key to continue");
        Console.ReadKey();
    }

    public static void AddHardware()
    {
        var reader = new StreamReader(File.OpenRead("../../../Hardwares/hardwareItems.txt"));
        List<string> list = [];
        while (reader.ReadLine() is { } line)
        {
            list.Add(line);
        }

        reader.Close();
        Console.WriteLine("Select hardware type: ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(i + ". " + list[i]);
        }

        var type = int.Parse(Console.ReadLine() ?? string.Empty);
        var hardware = list[type];
        var mytype = Type.GetType("APBDcw03.Hardwares." + hardware);
        Hardware newHardware = (Hardware)Activator.CreateInstance(mytype);
        foreach (var item in newHardware.GetType().GetProperties())
        {
            if (item.Name == "Id")
            {
                item.SetValue(newHardware, Guid.NewGuid());
                continue;
            }

            if (item.PropertyType == typeof(Status))
            {
                item.SetValue(newHardware, Status.Available);
                continue;
            }

            Console.WriteLine($"Enter {item.Name}: ");
            var value = Console.ReadLine();
            var converted = Convert.ChangeType(value, item.PropertyType);
            item.SetValue(newHardware, converted);
        }

        Storage.Stock.Add(newHardware);

        Console.WriteLine("Hardware added. Press any key to continue");
        Console.ReadKey();
    }

    public static void ShowCurrentStock()
    {
        for (var i = 0; i < Storage.Stock.Count; i++)
        {
            Console.WriteLine(i + ". " + Storage.Stock[i]);
        }

        if (Storage.Stock.Count == 0) Console.WriteLine("No items in stock");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public static void Borrow()
    {
        Console.WriteLine();
        //Borrowing will first display the current stock and will allow user to select some items from stock
        ShowCurrentStock();
        Console.WriteLine("Select item: ");
        var item = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Select date-of-return: ");
        var date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        var itemToBorrow = Storage.Stock[item];
        Console.WriteLine("Input your user id: ");
        var id = int.Parse(Console.ReadLine() ?? string.Empty);
        var user = Storage.Users.Find(x => x.Id == id);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        Storage.Stock.RemoveAt(item);
        itemToBorrow.Status = Status.Unavailable;
        RentalService rental = new(user, itemToBorrow, DateTime.Now, date);
        Storage.Borrowed.Add(rental);
        Console.WriteLine("Item Borrowed. Press any key to continue");
        Console.ReadKey();
    }

    public static void Return()
    {
        for (var i = 0; i < Storage.Borrowed.Count; i++)
        {
            Console.WriteLine(i + ". " + Storage.Borrowed[i]);
        }

        Console.WriteLine("Select item: ");
        var item = int.Parse(Console.ReadLine() ?? string.Empty);
        var date = DateTime.Now;
        var fees = 0.75;
    }

    public static void StatusChange()
    {
        Console.WriteLine("Status Change");
    }

    public static void ShowActiveUserRentals()
    {
        Console.WriteLine("Input user id:");
        var id = int.Parse(Console.ReadLine() ?? string.Empty);
        User user = Storage.Users.Find(x => x.Id == id);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        List<RentalService> rentals = Storage.Borrowed.FindAll(x => x.User == user);
        foreach (var item in rentals)
        {
            Console.WriteLine(item);
        }
        if (rentals.Count == 0) Console.WriteLine("User has no rentals");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        
    }

    public static void ShowOutOfDateRentals()
    {
        Console.WriteLine("Show User Rentals");
    }

    public static void GenerateReport()
    {
        Console.WriteLine("Generate Report");
    }
}