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

    public static void StatusChange()
    {
        ShowCurrentStock();
        Console.WriteLine("Select item: ");
        var item = int.Parse(Console.ReadLine() ?? string.Empty);
        var hardware = Storage.Stock[item];
        Console.WriteLine("Select new status: ");
        if (Enum.TryParse(Console.ReadLine() ?? string.Empty, out Status status))
        {
            hardware.Status = status;
            Console.WriteLine("Status changed");
        }
        else
        {
            Console.WriteLine("Invalid status");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        
    }
    public static void GenerateReport()
    {
        Console.WriteLine($"We have {Storage.Stock.Count} items in stock and {Storage.Borrowed.Count} items borrowed. Which meand that we have {Math.Round(100.0*Storage.Borrowed.Count/(Storage.Stock.Count+Storage.Borrowed.Count), 2)} % od our items are borrowed.\n" +
                          $"{Storage.Borrowed.FindAll(x => x.DateTo<DateTime.Now).Count} rentals are late on returns. \n" +
                          $"Our Service is used by {Storage.Users.Count} users. Where {Storage.Users.FindAll(x=> x.type == UserType.Student).Count} are students and {Storage.Users.FindAll(x=> x.type == UserType.Employee).Count} are employees.\n" +
                          $"Press any key to continue");
        Console.ReadKey();
    }
}