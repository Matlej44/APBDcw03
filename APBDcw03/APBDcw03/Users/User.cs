using APBDcw03.Service;

namespace APBDcw03.Users;

public class User
{
    public int Id{ get; set;}
    public string Name{ get; set;}
    public string Surname{ get; set;}
    public UserType type{ get; set;}

    public User( string name, string surname, UserType type)
    {
        Id = GenerateId();
        Name = name;
        Surname = surname;
        this.type = type;
    }

    private int GenerateId()
    {
        bool isIdUnique = false;
        int id = 0;
        while (!isIdUnique)
        {
            id = (int)(Random.Shared.NextDouble() * 10000);
            if(Storage.Users.Count == 0) isIdUnique = true;
            for (int i = 0; i < Storage.Users.Count; i++)
            {
                if (id == Storage.Users[i].Id)
                {
                    break;
                }
                if(i == Storage.Users.Count-1) isIdUnique = true;
            }
            
        }
        return id;
    }
    
    
}