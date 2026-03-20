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
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

               
                string[] files = Directory.GetFiles(folderPath);

                int count = 0;

                Console.WriteLine("\n File Details:\n");

                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);

                    Console.WriteLine("File Name   : " + info.Name);
                    Console.WriteLine("File Size   : " + info.Length + " bytes");
                    Console.WriteLine("Created On  : " + info.CreationTime);
                    Console.WriteLine("-----------------------------");

                    count++;
                }

                Console.WriteLine($"\n Total Files: {count}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to the folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }

        }

    }
}
