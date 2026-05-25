namespace CourseBudd.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // child ref
        public List<Module>? Modules { get; set; }
    }
}
