namespace CV.Domain.Entity;

public class Curriculum
{
    public string Name { get; set; }
    public ContactInfo Contact { get; set; }
    public ICollection<Education> Education { get; set; }
    public ICollection<Experience> Experience { get; set; }
    public ICollection<Certification> Certification { get; set; }
}
