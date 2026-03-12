using System;
using System.ComponentModel;

namespace ConsoleApp35
{
    internal class Program
    {
        class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
            public int Sub(int a, int b)
            {
                return a - b;
            }
        }


        static void Main(string[] args)
        {
            int a, b;
            bool flag;

            Console.Write("Enter First Number: ");
            flag = int.TryParse(Console.ReadLine(), out a);
            
            if(flag == false)
            {
                Console.Write("Enter Valid Number!");
                return;
            }
      
            Console.Write("Enter Second Number: ");
            flag = int.TryParse(Console.ReadLine(), out b);

            if (flag == false)
            {
                Console.Write("Enter Valid Number!");
                return;
            }
            Calculator c = new Calculator();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Addition: " + c.Add(a,b));
            Console.WriteLine("Substraction: " + c.Sub(a, b));

        }
    }
}

