namespace APBDcw03.Hardwares;

public class Projector : Hardware
{
    public int Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(int resolution, int brightness, string name, Status status = Status.Unknown) : base(name, status)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
    
}