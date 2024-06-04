namespace CV.Domain.Entity;

public class Experience
{
    public string Company { get; set; }
    public string City { get; set; }
    public string Position { get; set; }
    public string Period { get; set; }
    public ICollection<string> Description { get; set; }
}
