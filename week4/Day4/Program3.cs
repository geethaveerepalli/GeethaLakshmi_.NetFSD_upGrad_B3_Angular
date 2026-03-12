using System;
using System.ComponentModel;

namespace ConsoleApp35
{
    internal class Program
    {
       class Student
        {
            public double CalculateAverage(int m1, int m2, int m3)
            {
                double avg = (m1 + m2 + m3) / 3.0;
                return avg;
            } 
        } 

        static void Main(string[] args)
        {
            int m1, m2, m3;
            bool flag;
            Console.Write("Enter Marks 1: ");
            flag = int.TryParse(Console.ReadLine(), out m1);

            if(flag == false || m1 <0 || m1 > 100){
                Console.Write("please Enter a valid Number: ");
                return;
            }
            Console.Write("Enter Marks 2: ");
            flag = int.TryParse(Console.ReadLine(), out m2);

            if (flag == false || m2 < 0 || m2 > 100)
            {
                Console.Write("please Enter a valid Number: ");
                return;
            }
            Console.Write("Enter Marks 3: ");
            flag = int.TryParse(Console.ReadLine(), out m3);

            if (flag == false || m3 < 0 || m3 > 100)
            {
                Console.Write("please Enter a valid Number: ");
                return;
            }
            Student s = new Student();
            double avg = s.CalculateAverage(m1, m2, m3);
            string grade;

            if(avg >= 90)
            {
                grade = "A";
            }
            else if (avg >= 75)
            {
                grade = "B";
            }
            else if (avg >= 60)
            {
                grade = "C";
            }
            else if (avg >= 40)
            {
                grade = "D";
            }
            else
            {
                grade = "Fail";
            }
            Console.Write("-------------------------------\n");
            Console.WriteLine("Average Marks: " + avg);
            Console.WriteLine("Grade: " + grade);
        }
    }
}

