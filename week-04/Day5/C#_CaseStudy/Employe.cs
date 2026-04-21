using System;

namespace ConsoleApp39
{
    class Employee
    {
        private string fullName;
        private int age;
        private decimal salary;
        private readonly string employeeId;

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                fullName = value.Trim();
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 80)
                    throw new ArgumentException("Age must be between 18 and 80");

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary cannot be less than 1000");

                salary = value;
            }
        }

        public string EmployeeId
        {
            get { return employeeId; }
        }

        public Employee(string name, decimal startSalary, int empAge)
        {
            employeeId = "E" + new Random().Next(1000, 9999);

            FullName = name;
            Age = empAge;
            Salary = startSalary;
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise must be between 1 and 30 percent");

            Salary = Salary + (Salary * percentage / 100);

            Console.WriteLine("Salary increased. New Salary: " + Salary);
        }

        public bool DeductPenalty(decimal amount)
        {
            if (Salary - amount < 1000)
            {
                Console.WriteLine("Penalty rejected. Salary cannot go below 1000");
                return false;
            }

            Salary = Salary - amount;

            Console.WriteLine("Penalty deducted. New Salary: " + Salary);
            return true;
        }
    }
}