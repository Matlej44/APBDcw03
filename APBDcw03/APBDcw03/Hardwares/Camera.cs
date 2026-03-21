namespace APBDcw03.Hardwares;

public class Camera : Hardware
{
    public string Lens { get; set; }
    public int MegaPixels { get; set; }

    public Camera(string lens, int megaPixels, string name, Status status = Status.Unknown) : base(name, status)
    {
        Lens = lens;
        MegaPixels = megaPixels;
    }
    public Camera()
    {
        
    }
    
}