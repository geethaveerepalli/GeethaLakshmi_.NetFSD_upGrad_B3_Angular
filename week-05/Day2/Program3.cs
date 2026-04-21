using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp39
{
    internal class Program
    {
        class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException (String message) : base(message) 
            { 
            }
        }
        class BankAcount
        {
            private double _balance;

            public BankAcount(double balance)
            {
                _balance = balance;
            }

            public void Withdraw(double amount)
            {
                if(amount > _balance)
                {
                    throw new InsufficientBalanceException("Withdraw amount exceeds available balance");
                }

                _balance -= amount;
                Console.WriteLine($"Withdraw Sucess1 Remaining Balance: {_balance}");
            }
        }
        
        static void Main(string[] args)
        {

            Console.Write("Enter Balance: ");
            double bal = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Withdraw amount: ");
            double amt = double.Parse(Console.ReadLine());
            BankAcount account = new BankAcount(bal);

            try
            {
                account.Withdraw(amt);
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction Completed");
            }

            Console.WriteLine("Program will continue");
        }

    }
}
