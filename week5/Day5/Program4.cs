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
                Console.Write("Enter root directory path: ");
                string path = Console.ReadLine();

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("❌ Invalid directory path.");
                    return;
                }

                
                DirectoryInfo root = new DirectoryInfo(path);

                
                DirectoryInfo[] directories = root.GetDirectories();

                Console.WriteLine("\n Folder Details:\n");

                foreach (DirectoryInfo dir in directories)
                {
                    
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine("Folder Name : " + dir.Name);
                    Console.WriteLine("File Count  : " + files.Length);
                    Console.WriteLine("-----------------------------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }
        }

    }

}

