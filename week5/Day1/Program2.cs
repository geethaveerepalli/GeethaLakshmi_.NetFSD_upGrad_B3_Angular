using System;

namespace ConsoleApp39
{
    internal class Program
    {
        class Employee
        {
            public string Name { get; set; }
            public double BaseSalary { get; set; }

            public virtual double CalculateSalary()
            {
                return BaseSalary;
            }
        }
        class Manager: Employee
        {
            public override double CalculateSalary()
            {
                return BaseSalary + (BaseSalary* 0.20);
            }
        }

        class Developer : Employee
        {
            public override double CalculateSalary()
            {
                return BaseSalary + (BaseSalary * 0.10);
            }
        }
             
        static void Main(string[] args)
        {
            Console.Write("Enter Base Slary: ");
            double salary = double.Parse(Console.ReadLine());

            Employee emp;
            emp = new Manager();
            emp.Name = "Manager";
            emp.BaseSalary = salary;
            Console.WriteLine($"Manager Salary = {emp.CalculateSalary()}");

            emp = new Developer();
            emp.Name = "Developer";
            emp.BaseSalary = salary;
            Console.WriteLine($"Developer Salary = {emp.CalculateSalary()}");

            Console.ReadLine();

        }
    }
}