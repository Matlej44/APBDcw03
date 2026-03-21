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
    public void Return()
    {
        ReturnDate = DateTime.Now;
    }
    public void Rent()
    {
        DateFrom = DateTime.Now;
    }
}