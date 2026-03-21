using APBDcw03.Hardwares;
using APBDcw03.Users;

namespace APBDcw03.Service;

public static class Storage
{
    public static List<Hardware> Stock = [];
    public static List<User> Users = [];
    public static List<RentalService> Borrowed = [];
}