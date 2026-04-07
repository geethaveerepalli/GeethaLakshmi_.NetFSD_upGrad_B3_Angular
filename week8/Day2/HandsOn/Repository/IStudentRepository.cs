using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
        IEnumerable<Course> GetAllCourses();
        void AddStudent(Student student);
    }
}
