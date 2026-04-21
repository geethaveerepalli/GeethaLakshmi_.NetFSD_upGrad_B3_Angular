using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp39
{
    internal class Program
    {
        public record Student(int RollNumber, string Name, string Course, int Marks);
        static void Main(string[] args)
        {


            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                int roll;
                int marks;

                // Roll Number validation
                while (true)
                {
                    Console.Write("Enter Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                        break;
                    Console.WriteLine("Invalid Roll Number! Try again.");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                // Marks validation
                while (true)
                {
                    Console.Write("Enter Marks: ");
                    if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                        break;
                    Console.WriteLine("Invalid Marks! Enter between 0 and 100.");
                }

                students[i] = new Student(roll, name, course, marks);
                Console.WriteLine();
            }

            // Display all records
            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }

            // Search student
            Console.Write("\nSearch Roll Number: ");
            int searchRoll = int.Parse(Console.ReadLine());

            Student foundStudent = null;

            foreach (var s in students)
            {
                if (s.RollNumber == searchRoll)
                {
                    foundStudent = s;
                    break;
                }
            }

            Console.WriteLine("\nSearch Result:");
            if (foundStudent != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine($"Roll No: {foundStudent.RollNumber} | Name: {foundStudent.Name} | Course: {foundStudent.Course} | Marks: {foundStudent.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

        }

    }
}
