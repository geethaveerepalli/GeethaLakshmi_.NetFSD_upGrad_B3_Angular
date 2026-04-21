using System;

namespace OCP_DiscountSystem
{
   
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // Regular Customer Discount
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10; 
        }
    }

    // Premium Customer Discount
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; 
        }
    }

    //  VIP Customer Discount
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.30; 
        }
    }

    //  Discount Calculator 
    public class DiscountCalculator
    {
        private IDiscountStrategy _discountStrategy;

        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public double GetFinalAmount(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    // Main Program 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter purchase amount: ");
                double amount;

                // Validate amount input
                if (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Invalid amount!");
                    return;
                }

                Console.WriteLine("\nSelect Customer Type:");
                Console.WriteLine("1. Regular Customer");
                Console.WriteLine("2. Premium Customer");
                Console.WriteLine("3. VIP Customer");

                Console.Write("Enter your choice: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                IDiscountStrategy strategy = null;


                switch (choice)
                {
                    case 1:
                        strategy = new RegularCustomerDiscount();
                        break;
                    case 2:
                        strategy = new PremiumCustomerDiscount();
                        break;
                    case 3:
                        strategy = new VipCustomerDiscount();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected!");
                        return;
                }

               
                DiscountCalculator calculator = new DiscountCalculator(strategy);
                double finalAmount = calculator.GetFinalAmount(amount);

                Console.WriteLine("\n----- Bill Details -----");
                Console.WriteLine("Original Amount : " + amount);
                Console.WriteLine("Discount Applied: " + strategy.CalculateDiscount(amount));
                Console.WriteLine("Final Amount    : " + finalAmount);
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