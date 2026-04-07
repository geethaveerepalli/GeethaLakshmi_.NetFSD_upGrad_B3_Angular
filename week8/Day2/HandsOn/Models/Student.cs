namespace WebApplication9.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
