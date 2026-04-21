namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            double salary, bonus, finalSalary;
            int experience;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Experience (years): ");
            experience = int.Parse(Console.ReadLine());

            if (experience < 2)
            {
                bonus = salary * 0.05;
            }
            else if (experience <= 5)
            {
                bonus = salary * 0.10;
            }
            else
            {
                bonus = salary * 0.15;
            }

            // Using ternary operator
            finalSalary = bonus > 0 ? salary + bonus : salary;

            Console.WriteLine($"Employee: {name}");
            Console.WriteLine($"Bonus: {bonus:F2}");
            Console.WriteLine($"Final Salary: {finalSalary:F2}");
        }
    }
}
