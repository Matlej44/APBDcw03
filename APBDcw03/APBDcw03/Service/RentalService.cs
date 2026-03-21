using APBDcw03.Hardwares;
using APBDcw03.Users;

namespace APBDcw03.Service;

public class RentalService
{
    public Users.User User{ get; set;}
    public Hardwares.Hardware Hardware{ get; set;}
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public DateTime? ReturnDate { get; set; }

    public double Fee = 0.75;

    public RentalService(User user, Hardware hardware, DateTime dateFrom, DateTime dateTo)
    {
        User = user;
        Hardware = hardware;
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
    public void Rent()
    {
        DateFrom = DateTime.Now;
    }

    public override string ToString()
    {
        return Hardware.Name + " " + DateFrom + " " + DateTo+" "+ReturnDate;
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
        List<RentalService> rentals = Storage.Borrowed.FindAll(x => x.ReturnDate < DateTime.Now);
    }
    public static void Borrow()
    {
        Console.WriteLine();
        //Borrowing will first display the current stock and will allow user to select some items from stock
        FunctionService.ShowCurrentStock();
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
}