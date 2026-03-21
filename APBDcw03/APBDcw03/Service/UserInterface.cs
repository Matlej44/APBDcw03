namespace APBDcw03.Service;

public class UserInterface
{
    public static void AddUser()
    {
        Storage.Users.Add(Console.ReadLine() ?? string.Empty);
    }

    public static void AddHardware()
    {
        Storage.Stock.Add(Console.ReadLine() ?? string.Empty);
    }

    public static void ShowCurrentStock()
    {
        for (var i = 0; i < Storage.Stock.Count; i++)
        {
            Console.WriteLine(i+". "+Storage.Stock[i]);
        }
    }

    public static void Borrow()
    {
        //Borrowing will first display the current stock and will allow user to select some items from stock
        ShowCurrentStock();
        Console.WriteLine("Select item: ");
        var item = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Select date-of-return: ");
        var date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        var itemToBorrow = Storage.Stock[item];
        Storage.Stock.RemoveAt(item);
        Storage.Borrowed.Add(itemToBorrow);
        
    }

    public static void Return()
    {
        for (var i = 0; i < Storage.Borrowed.Count; i++)
        {
            Console.WriteLine(i+". "+Storage.Borrowed[i]);
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
        Console.WriteLine("Show Active User Rentals");
    }

    public static void ShowUserRentals()
    {
        Console.WriteLine("Show User Rentals");
    }
    public static void GenerateReport()
    {
        Console.WriteLine("Generate Report");
    }
}