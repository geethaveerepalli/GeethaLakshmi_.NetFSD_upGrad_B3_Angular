using System;
using System.Collections;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp39
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string filePath = "log.txt";

            try
            {
                while (true)
                {
                    Console.Write("Enter message: ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                        break;

                    // Convert string to bytes
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                    // Open file in Append mode
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }

                    Console.WriteLine(" Message written successfully!\n");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(" Access denied to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(" File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Unexpected error: " + ex.Message);
            }

        }

    }
}
