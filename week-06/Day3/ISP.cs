using System;

namespace LSP_ShapeCalculator
{
    // Base Class
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Rectangle Class
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }
    }

    // Circle Class
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // Area Calculator (Uses Base Class)
    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            double area = shape.CalculateArea();
            Console.WriteLine("Calculated Area: " + area);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AreaCalculator calculator = new AreaCalculator();

                Console.WriteLine("Choose Shape:");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Circle");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Shape shape = null;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Length: ");
                        double length = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Width: ");
                        double width = Convert.ToDouble(Console.ReadLine());

                        shape = new Rectangle(length, width);
                        break;

                    case 2:
                        Console.Write("Enter Radius: ");
                        double radius = Convert.ToDouble(Console.ReadLine());

                        shape = new Circle(radius);
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }

                // LSP in action
                calculator.PrintArea(shape);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}