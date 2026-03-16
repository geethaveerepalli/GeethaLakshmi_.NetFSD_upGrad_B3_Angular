using System;

namespace ConsoleApp39
{
    internal class Program
    {
        class Product
        {
            private string _name;
            private double _price;

            public string Name
            {
                get { return _name;}
                set { _name = value; }
            }

            public double Price
            {
                get { return _price; }
                set { 
                if (value >= 0)
                    {
                        _price = value;
                    }
                    else
                    {
                        Console.WriteLine("Price cannot be negative");
                    }
                }
            }
            public virtual double CalculateDiscount()
            {
                return Price;
            }
        }

        class Electronics : Product
        {
            public override double CalculateDiscount()
            {
                return Price - (Price * 0.05);
            }
        }
         
        class Clothing : Product
        {
            public override double CalculateDiscount()
            {
                return Price - (Price * 0.15);
            }
        }
             
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Electronics Price: ");
            double eprice = double.Parse(Console.ReadLine());

            Product p;
            p = new Electronics();
            p.Name = "Electronics";
            p.Price = eprice;
            Console.WriteLine($"Final Price after 5% discount = {p.CalculateDiscount()}");

            Console.Write("Enter Clothing Price: ");
            double cprice = double.Parse(Console.ReadLine());

            p = new Clothing();
            p.Name = "Clothing";
            p.Price = cprice;

            Console.WriteLine($"Final Price after 15% discount = {p.CalculateDiscount()}");

            Console.ReadLine();
        }
    }
}
