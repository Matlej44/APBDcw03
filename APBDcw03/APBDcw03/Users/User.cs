namespace APBDcw03.Users;

public abstract class User
{
    Guid id = Guid.NewGuid();
    string name;
    string surname;
    UserType type;
}