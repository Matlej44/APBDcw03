namespace APBDcw03;

public class Laptop : Hardware
{
    public int Ram { get; set; }
    public int Hdd { get; set; }
    public int Cpu { get; set; }
    public int Screen { get; set; }

    public Laptop(int ram, int hdd, int cpu, int screen, string name, Status status = Status.Unknown) : base(name, status)
    {
        Ram = ram;
        Hdd = hdd;
        Cpu = cpu;
        Screen = screen;
    }
    
}