namespace CV.Domain.Entity;

public class WorkExperience
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public List<string> Technologies { get; set; }
}
