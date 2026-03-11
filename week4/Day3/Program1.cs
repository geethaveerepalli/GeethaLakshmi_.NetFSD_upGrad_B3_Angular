namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int marks;
            string grade;

            Console.Write("Enter Student name: ");
            name = Console.ReadLine();

            Console.Write("Enter Student Marks: ");
            marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks!");
                return;
            }
            else if (marks >= 90)
            {
                grade = "A";
            }
            else if (marks >= 75)
            {
                grade = "B";
            }
            else if (marks >= 60)
            {
                grade = "C";
            }
            else if (marks >= 40)
            {
                grade = "D";
            }
            else
            {
                grade = "Fail";
            }

            Console.WriteLine($"Student: {name}");
            Console.WriteLine($"Marks: {marks}");
            Console.WriteLine($"Grade: {grade}");
        }
    }
}
