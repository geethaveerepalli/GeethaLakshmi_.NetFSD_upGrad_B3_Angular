using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main(string[] args)        {
            Console.WriteLine("Application Started...");

            
            Task t1 = WriteLogAsync("User logged in");
            Task t2 = WriteLogAsync("File uploaded");
            Task t3 = WriteLogAsync("Data saved");

            Console.WriteLine("Main thread is still running...");
            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("All logs written successfully.");        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");
            await Task.Delay(2000);

            Console.WriteLine($"Log written: {message}");
        }
    }
}