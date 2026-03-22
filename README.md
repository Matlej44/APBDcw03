# APBDcw03 Collage Rental Service

## Description
Program is a hardware collage rental service  with a text User Interface.

## Quick start
1. Clone the repository.
2. Open project APBDcw03.sln with JetBrains Rider or visual studio.
3. Make sure the file `Hardwares/hardwareitems.txt` is correctly attached(The path is relative to your EXE file.)
4. Launch project the point of entry is method Main in `Program.cs`.

Requirements is .NET 8+ SDK

## Project structure

```
APBDcw03/
├── Hardwares/
│   ├── Hardware.cs        #Abstract class
│   ├── Laptop.cs
│   ├── Camera.cs
│   ├── Projector.cs
│   ├── Status.cs           # Enum
│   └── hardwareItems.txt   # List of creatable classes used in adding hardware function
├── Users/
│   ├── User.cs             
│   └── UserType.cs         # Enum
├── Service/
│   ├── Storage.cs          # Static class that stores all data like database
│   ├── RentalService.cs    # Service with logic on borrowing and returning
│   └── FunctionService.cs  # Service to operate the User interface functions
└── Program.cs              # Main menu and starting point of a function
```

## Funkcjonalności
 
| # | Funkcja |
|---|---------|
| 1 | Adding new user(Student / Employee) |
| 2 | Adding new hardware (Laptop, Projector, Camera) |
| 3 | Showing current stock with its status |
| 4 | Borrowing the hardware |
| 5 | The returning of the hardware |
| 6 | Change of status to our hardware |
| 7 | Showing user rentals |
| 8 | Showing rentals that are out of date |
| 9 | Genarating the raport of the current status |

## Projecty Decisions

### Extending
`Laptop, Camera i Projektor` extend from a abstract `Hardware` class, because they have same fields(ID, Name, Status).

### Dynamic object creation
`FunctionService.AddHardware()` uses reflective programing to create an instance of a class. It uses a txt file to read what classes are avaible to create. Thanks to that we don't have to modify `AddHardware()` function when we decide to add new Hardware class.

### Exception handling
The bad operation like borrowing Unaviable hardware are handled by showing a message to user and going back to the main menu not stoping the program.
