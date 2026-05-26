namespace CourseBudd.Models
{
    public class Module
    {
        // PK
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // FK
        public int SubjectId { get; set; }
        // parent ref
        public Subject? Subject { get; set; }

    }
}
