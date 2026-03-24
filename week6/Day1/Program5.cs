using System;using System.Diagnostics;using System.IO;using System.Net.Http;using System.Threading.Tasks;namespace ConsoleApp8{    class Program    {        static void Main()
        {
            TextWriterTraceListener listener = new TextWriterTraceListener("OrderLog.txt");
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Order processed successfully.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error occurred: " + ex.Message);
            }

            Console.WriteLine("Processing Completed. Check log file.");
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating Order...");
            Thread.Sleep(1000);
            Trace.TraceInformation("Order validated.");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing Payment...");
            Thread.Sleep(1000);
            Trace.TraceInformation("Payment successful.");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating Inventory...");
            Thread.Sleep(1000);
            Trace.TraceInformation("Inventory updated.");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating Invoice...");
            Thread.Sleep(1000);
            Trace.TraceInformation("Invoice generated.");
        }
    }
}