using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main()
        {
            Console.WriteLine("Order Processing Started...\n");

            await ProcessOrder();

            Console.WriteLine("\nOrder Processing Completed.");
        }

        static async Task ProcessOrder()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Payment Verification Started...");
            await Task.Delay(2000);
            Console.WriteLine("Payment Verified.");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Inventory Check Started...");
            await Task.Delay(1500);
            Console.WriteLine("Inventory Available.");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Order Confirmation Started...");
            await Task.Delay(1000);
            Console.WriteLine("Order Confirmed.");
        }
    }
}