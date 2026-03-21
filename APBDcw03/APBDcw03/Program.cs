using APBDcw03.Hardwares;
using APBDcw03.Service;
using APBDcw03.Users;

namespace APBDcw03;

class Program
{
    static void Main(string[] args)
    {
        //Initilize with some data for testing purposes
        Storage.Stock.Add(new Laptop(16, "Intel Core i5", "Laptop 1" ));
        Storage.Stock.Add(new Camera("18-55mm", 16, "Kamera 1"));
        Storage.Stock.Add(new Camera("18-70mm", 32, "Kamera 2"));
        Storage.Stock.Add(new Projector("1920x1080", 50, "Projektor 1"));
        Storage.Users.Add(new User(10, "Jan","Kowalski", UserType.Student));
        Storage.Users.Add(new User(11, "Anna","Nowak", UserType.Employee));
        Storage.Borrowed.Add(new RentalService(Storage.Users[0], new Laptop(16, "Intel Core i5", "Laptop 2" ), DateTime.Now, DateTime.Now.AddDays(1)));
        Storage.Borrowed.Add(new RentalService(Storage.Users[1], new Projector("1920x1080", 50, "Projektor 2" ), DateTime.Now, DateTime.Now.AddDays(-1)));
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Witaj w aplikacji co chciałbyś wykonać.\n" +
                              "\t 1. Dodać nowego użytkownika.\n" +
                              "\t 2. Dodawanie nowego sprzetu.\n" +
                              "\t 3. Wyswietlenie listy sprzetu z aktualnym statutem.\n" +
                              "\t 4. Wypozyczenie/Zwrot.\n" +
                              "\t 5. Zmiana statusu Sprzetu\n" +
                              "\t 6. Wyswietlenie aktywnych wypozyczen danego uzytkownika.\n" +
                              "\t 7. Wyswietlenie listy przeterminowanych wyporzyczen.\n" +
                              "\t 8. Wygenerowanie krótkiego raportu.\n" +
                              "\t q. Quit");
            var chr = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (chr)
            {
                case '1':
                    FunctionService.AddUser();
                    break;
                case '2':
                    FunctionService.AddHardware();
                    break;
                case '3':
                    FunctionService.ShowCurrentStock();
                    break;
                case '4':
                    Console.WriteLine(" 1. Wypożyczanie\n 2. Zwrot");
                    if (Console.ReadKey().KeyChar == '1') RentalService.Borrow();
                    else if (Console.ReadKey().KeyChar == '2') RentalService.Return();
                    break;
                case '5':
                    FunctionService.StatusChange();
                    break;
                case '6':
                    RentalService.ShowActiveUserRentals();
                    break;
                case '7':
                    RentalService.ShowOutOfDateRentals();
                    break;
                case '8':
                    FunctionService.GenerateReport();
                    break;
                case 'q':
                    return;
            }
        }
        
    }
}