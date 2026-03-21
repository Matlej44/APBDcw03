using APBDcw03.Service;

namespace APBDcw03;

class Program
{
    static void Main(string[] args)
    {
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
                              "\t 7. Wyswietlenie listy wyporzyczen danego uzytkownika.\n" +
                              "\t 8. Wygenerowanie krótkiego raportu");
            var chr = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (chr)
            {
                case '1':
                    UserInterface.AddUser();
                    break;
                case '2':
                    UserInterface.AddHardware();
                    break;
                case '3':
                    UserInterface.ShowCurrentStock();
                    break;
                case '4':
                    Console.WriteLine(" 1. Wypożyczanie\n 2. Zwrot");
                    if (Console.ReadKey().KeyChar == '1') UserInterface.Borrow();
                    else if (Console.ReadKey().KeyChar == '2') UserInterface.Return();
                    break;
                case '5':
                    UserInterface.StatusChange();
                    break;
                case '6':
                    UserInterface.ShowActiveUserRentals();
                    break;
                case '7':
                    UserInterface.ShowUserRentals();
                    break;
                case '8':
                    UserInterface.GenerateReport();
                    break;
                case 'q':
                    return;
            }
        }
        
    }
}