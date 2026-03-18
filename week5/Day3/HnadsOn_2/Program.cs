using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp39
{
    internal class Program
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        // ✅ Method to get list
        public static List<Program> GetProducts()
        {
            return new List<Program>
            {
                new Program{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Program{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Program{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Program{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Program{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Program{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Program{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Program{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Program{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Program{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Program{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Program{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Program{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }

        static void Main(string[] args)
        {
            var products = GetProducts();

            // 1.Write a LINQ query to search and display all products with category “FMCG”.
            Console.WriteLine("\n--- FMCG ---");
            var q1 = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in q1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            //2.Write a LINQ query to search and display all products with category “Grain”.
            Console.WriteLine("\n----Grain----");
            var q2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in q2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            //3.Write a LINQ query to sort products in ascending order by product code.
            Console.WriteLine("\n--- Sort Code ---");
            var q3 = products.OrderBy(p => p.ProCode);
            foreach (var item in q3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");

            // 4.Write a LINQ query to sort products in ascending order by product Category.
            Console.WriteLine("\n--- Sort Category ---");
            var q4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in q4)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");

            //5.Write a LINQ query to sort products in ascending order by product Mrp.
            Console.WriteLine("\n--- MRP Asc ---");
            var q5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in q5)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            //6.Write a LINQ query to sort products in descending order by product Mrp
            Console.WriteLine("\n--- MRP Desc ---");
            var q6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in q6)
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");

            //7.Write a LINQ query to display products group by product Category.
            Console.WriteLine("\n--- Group Category ---");
            var q7 = products.GroupBy(p => p.ProCategory);
            foreach (var g in q7)
            {
                Console.WriteLine(g.Key);
                foreach (var item in g)
                    Console.WriteLine($"   {item.ProName}");
            }

            //8.Write a LINQ query to display products group by product Mrp.
            Console.WriteLine("\n--- Group MRP ---");
            var q8 = products.GroupBy(p => p.ProMrp);
            foreach (var g in q8)
            {
                Console.WriteLine(g.Key);
                foreach (var item in g)
                    Console.WriteLine($"   {item.ProName}");
            }

            //9.Write a LINQ query to display product detail with highest price in FMCG category.
            Console.WriteLine("\n--- Max FMCG ---");
            var q9 = products.Where(p => p.ProCategory == "FMCG")
                             .OrderByDescending(p => p.ProMrp)
                             .First();
            Console.WriteLine($"{q9.ProName} - {q9.ProMrp}");


            //10.Write a LINQ query to display count of total products.
            Console.WriteLine("\n--- Total Count ---");
            Console.WriteLine(products.Count());

            //11.Write a LINQ query to display count of total products with category FMCG.
            Console.WriteLine("\n--- FMCG Count ---");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            //12.Write a LINQ query to display Max price.

            Console.WriteLine("\n--- Max Price ---");
            Console.WriteLine(products.Max(p => p.ProMrp));

            //13.Write a LINQ query to display Min price.
            Console.WriteLine("\n--- Min Price ---");
            Console.WriteLine(products.Min(p => p.ProMrp));

            //14.Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("\n--- All below 30 ---");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            // 15.Write a LINQ query to display whether any products are below Mrp Rs.30 or not
            Console.WriteLine("\n--- Any below 30 ---");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }



    }
}
