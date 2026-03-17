using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp39
{
    internal class Program
    {
       class Vehicle
        {
            private string _brand;
            private double _rentalRatePerDay;

            public string Brand
            {
                get { return _brand; }
                set { _brand = value; }
            }

            public double RentalRatePerDay
            {
                get
                {
                    return _rentalRatePerDay;
                }
                set
                {
                    if (value >=0)
                        _rentalRatePerDay = value;
                    else
                        Console.WriteLine("Rental rate cannot be negative");
                }
            }
            public virtual double CalculateRental(int days)
            {
                return RentalRatePerDay * days;
            }
        }

        class car : Vehicle
        {
            public override double CalculateRental(int days)
            {
               if(days <= 0)
                {
                    Console.WriteLine("Invalid number of days!");
                    return 0;
                }
                return (RentalRatePerDay * days) + 500;
            }
        }
        class Bike : Vehicle
        {
            public override double CalculateRental(int days)
            {
                if(days <= 0)
                {
                    Console.WriteLine("Invalid number of days");
                    return 0;
                }
                double total = RentalRatePerDay * days;
                return total - (total * 0.05);
            }
        }
        static void Main(string[] args)
        {
            Vehicle v;
            Console.Write("Enter Car Rental Rate Per Day: ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter Days: ");
            int days = int.Parse(Console.ReadLine());

            v = new car();
            v.RentalRatePerDay = rate;

            Console.WriteLine($"Total Rental = {v.CalculateRental(days)}");


            Console.Write("Enter Bike Rental Rate Per Day: ");
            rate = double.Parse(Console.ReadLine());

            Console.Write("Enter Days: ");
            days = int.Parse(Console.ReadLine());

            v = new Bike();
            v.RentalRatePerDay = rate;

            Console.WriteLine($"Total Rental = {v.CalculateRental(days)}");

            Console.ReadLine();
        }
    }
}
