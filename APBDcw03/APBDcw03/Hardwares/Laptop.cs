namespace APBDcw03.Hardwares;

public class Laptop : Hardware
{
    public int Ram { get; set; }
    public string Cpu { get; set; }

    public Laptop(int ram, string cpu, string name, Status status = Status.Unknown) : base(name, status)
    {
        Ram = ram;
        Cpu = cpu;
    }

    public Laptop()
    {
        
    }

    public override string ToString()
    {
        return base.ToString()+" Ram: " + Ram + " Cpu: " + Cpu + "";
    }
}