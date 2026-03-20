using System;
using System.Collections;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp39
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Sales Amount: ");
            decimal sales = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Customer Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            
            var result = GetPerformanceData(sales, rating);

            
            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            
            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine("Employee Name : " + name);
            Console.WriteLine("Sales Amount  : " + result.sales);
            Console.WriteLine("Rating        : " + result.rating);
            Console.WriteLine("Performance   : " + performance);
        }

      
        static (decimal sales, int rating) GetPerformanceData(decimal sales, int rating)
        {
            return (sales, rating);
        }

    }

}

