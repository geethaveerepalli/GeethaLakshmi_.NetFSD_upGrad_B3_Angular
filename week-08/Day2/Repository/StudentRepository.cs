using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            using (var db = Connection)
            {
                string sql = @"SELECT s.StudentId, s.StudentName, s.CourseId,
                           c.CourseId, c.CourseName
                           FROM Students s
                           INNER JOIN Courses c ON s.CourseId = c.CourseId";

                return db.Query<Student, Course, Student>(
                    sql,
                    (student, course) =>
                    {
                        student.Course = course;
                        return student;
                    },
                    splitOn: "CourseId"
                ).ToList();
            }
        }


        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = Connection)
            {
                string sql = @"SELECT c.CourseId, c.CourseName,
                           s.StudentId, s.StudentName, s.CourseId
                           FROM Courses c
                           LEFT JOIN Students s ON c.CourseId = s.CourseId";

                var dict = new Dictionary<int, Course>();

                var list = db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!dict.TryGetValue(course.CourseId, out var current))
                        {
                            current = course;
                            current.Students = new List<Student>();
                            dict.Add(current.CourseId, current);
                        }

                        if (student != null)
                            current.Students.Add(student);

                        return current;
                    },
                    splitOn: "StudentId"
                );

                return dict.Values;
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            using (var db = Connection)
            {
                return db.Query<Course>("SELECT * FROM Courses").ToList();
            }
        }

        public void AddStudent(Student student)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Students(StudentName, CourseId)
                           VALUES(@StudentName, @CourseId)";
                db.Execute(sql, student);
            }
        }
    }
}

