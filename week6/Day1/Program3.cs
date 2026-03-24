using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main()
        {
            Console.WriteLine("Starting report generation...\n");
            Task t1 = GenerateSalesReport();
            Task t2 = GenerateInventoryReport();
            Task t3 = GenerateCustomerReport();

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("\nAll reports generated successfully.");
        }

        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started...");
            await Task.Delay(2000); 
            Console.WriteLine("Sales Report Completed.");
        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started...");
            await Task.Delay(3000);
            Console.WriteLine("Inventory Report Completed.");
        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            await Task.Delay(1500);
            Console.WriteLine("Customer Report Completed.");
        }
    }
}