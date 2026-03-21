namespace APBDcw03;

public class UserInterface
{
    public static void AddUser()
    {

        Console.WriteLine("Add User");
    }

    public static void AddHardware()
    {
        Console.WriteLine("Add Hardware");
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
        
    }

    public static void Return()
    {
        Console.WriteLine("Return");
    }

    public static void StatusChange()
    {
        Console.WriteLine("Status Change");
    }

    public static void ShowUserRentals()
    {
        Console.WriteLine("Show User Rentals");
    }
}