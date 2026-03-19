namespace APBDcw03;

public abstract class Hardware
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }

    
    public Hardware(string name,  Status status=Status.Unknown)
    {
        this.Id =  Guid.NewGuid();
        this.Name = name;
        this.Status = status;
    }
}