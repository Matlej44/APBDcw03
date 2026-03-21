namespace APBDcw03.Hardwares;

public abstract class Hardware
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }


    protected Hardware(string name,  Status status=Status.Unknown)
    {
        this.Id =  Guid.NewGuid();
        this.Name = name;
        this.Status = status;
    }

    public Hardware()
    {
        
    }
    public void RepairHardware()
    {
        Status = Status.Available;
    }

    public override string ToString()
    {
        return "Name: " + Name + " Status: " + Status + "";
    }
    
}