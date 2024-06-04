namespace CV.Domain.Entity
{
    public class Curriculum
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
        public List<Certification> Certification { get; set; }
    }
}
