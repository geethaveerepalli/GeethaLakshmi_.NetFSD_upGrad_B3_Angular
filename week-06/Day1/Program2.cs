using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static void Main(string[] args)        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount (%): ");
            double discount = Convert.ToDouble(Console.ReadLine());

            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("Product: " + productName);
            Console.WriteLine("Final Price: " + finalPrice);        }
    }
}