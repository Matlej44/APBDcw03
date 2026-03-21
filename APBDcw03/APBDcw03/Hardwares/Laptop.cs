namespace APBDcw03.Hardwares;

public class Laptop : Hardware
{
    public int Ram { get; set; }
    public int Cpu { get; set; }

    public Laptop(int ram, int cpu, string name, Status status = Status.Unknown) : base(name, status)
    {
        Ram = ram;
        Cpu = cpu;
    }
}