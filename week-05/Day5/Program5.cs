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
                // Get all drives
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("Drive Details:\n");

                foreach (DriveInfo drive in drives)
                {
                   
                    if (drive.IsReady)
                    {
                        long total = drive.TotalSize;
                        long free = drive.AvailableFreeSpace;

                        double freePercent = (double)free / total * 100;

                        Console.WriteLine("Drive Name   : " + drive.Name);
                        Console.WriteLine("Drive Type   : " + drive.DriveType);
                        Console.WriteLine("Total Size   : " + total + " bytes");
                        Console.WriteLine("Free Space   : " + free + " bytes");
                        Console.WriteLine("Free %       : " + freePercent.ToString("F2") + "%");

                        if (freePercent < 15)
                        {
                            Console.WriteLine(" Warning: Low disk space!");
                        }

                        Console.WriteLine("-----------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

}

