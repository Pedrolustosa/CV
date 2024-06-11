namespace CV.Domain.Entity;

public class Curriculum
{
    public Contact Contact { get; set; }
    public List<Education> Educations { get; set; }
    public List<WorkExperience> WorkExperiences { get; set; }
    public List<Certification> Certifications { get; set; }
}
