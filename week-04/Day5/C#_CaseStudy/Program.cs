using System;

namespace ConsoleApp39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Mark", 4500, 35);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(10);
            emp.DeductPenalty(500);

            Console.WriteLine("Final Salary: " + emp.Salary);

            Console.ReadLine();
        }
    }
}