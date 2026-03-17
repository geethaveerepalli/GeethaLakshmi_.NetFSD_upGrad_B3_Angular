using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp39
{
    internal class Program
    {
        class Calculator
        {
            public void Divide(int numerator, int denominator)
            {
                try
                {
                    int result = numerator / denominator;
                    Console.WriteLine($"Result: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero");
                }
                finally
                {
                    Console.WriteLine("Operation Completed!");
                }
            }
        }
        static void Main(string[] args)
        {

            Calculator calc = new Calculator();
            Console.Write("Enter Numerator: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Enter Denominator: ");
            int den = int.Parse(Console.ReadLine());

            calc.Divide(num, den);


        }

    }
}
