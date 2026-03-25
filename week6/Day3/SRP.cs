using System;
using System.Collections.Generic;

namespace SRP_StudentReport
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }

    //  StudentRepository (Only Data Management)
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            
            if (student.Marks < 0 || student.Marks > 100)
            {
                throw new ArgumentException("Marks must be between 0 and 100.");
            }

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    //  ReportGenerator (Only Report Logic)
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n----- Student Report -----");

            foreach (var student in students)
            {
                string grade = CalculateGrade(student.Marks);

                Console.WriteLine($"ID    : {student.StudentId}");
                Console.WriteLine($"Name  : {student.StudentName}");
                Console.WriteLine($"Marks : {student.Marks}");
                Console.WriteLine($"Grade : {grade}");
                Console.WriteLine("-------------------------");
            }
        }

        private string CalculateGrade(int marks)
        {
            if (marks >= 80) return "A";
            else if (marks >= 60) return "B";
            else if (marks >= 40) return "C";
            else return "Fail";
        }
    }

    // Main Program (User Input)
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repo = new StudentRepository();

            try
            {
                Console.Write("Enter number of students: ");
                int count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\nEnter details for Student {i + 1}:");

                    Console.Write("Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Marks: ");
                    int marks = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student
                    {
                        StudentId = id,
                        StudentName = name,
                        Marks = marks
                    };

                    repo.AddStudent(student);
                }

                // Generate Report
                ReportGenerator report = new ReportGenerator();
                report.GenerateReport(repo.GetAllStudents());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter correct data type.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}