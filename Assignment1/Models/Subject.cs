namespace CourseBudd.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EnrolledStudents { get; set; } = 0;
        // child ref
        public List<Module>? Modules { get; set; }
    }
}
