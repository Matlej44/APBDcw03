namespace APBDcw03.Hardwares;

public class Projector : Hardware
{
    public string Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(string resolution, int brightness, string name, Status status = Status.Unknown) : base(name, status)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
    public Projector()
    {
        
    }
}