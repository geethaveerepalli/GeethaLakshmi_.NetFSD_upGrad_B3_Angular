using System;

namespace ConsoleApp39
{
    internal class Program
    {
        class BankAccount
        {
            private int _accountNumber;
            private double _balance;

            public int AccountNumber
            {
                get { return _accountNumber; }
                set { _accountNumber = value;}
            }

            public double Balance
            {
                get { return _balance; }
            }

            public void Deposit(double amount)
            {
                if(amount > 0)
                {
                    _balance += amount;
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount");
                }
            }
             public void Withdraw(double amount)
            {
                if(amount <= 0)
                {
                    Console.WriteLine("Invalid withdraw amount");
                }
                else if (amount > _balance)
                {
                    Console.WriteLine("Insufficient Balance");
                }
                else
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdraw Amount : {amount}");
                 
                }
            }
        }
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();
            Console.Write("Enter Account Number: ");
            acc.AccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double depositAmount = double.Parse(Console.ReadLine());

            acc.Deposit(depositAmount);
            Console.Write("Enter Withdraw Amount: ");
            double withdrawAmount = double.Parse(Console.ReadLine());

            acc.Withdraw(withdrawAmount);

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Final Balance = {acc.Balance}");

            Console.ReadLine();

        }
    }
}