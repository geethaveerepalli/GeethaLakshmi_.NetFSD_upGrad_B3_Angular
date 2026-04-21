using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DisconnectedCRUD
{
    internal class Program
    {
        static string connStr;

        static void Main(string[] args)
        {
            // Read connection string
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n--- PRODUCT MENU (DISCONNECTED) ---");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1: InsertProduct(); break;
                    case 2: ViewProducts(); break;
                    case 3: UpdateProduct(); break;
                    case 4: DeleteProduct(); break;
                    case 5: return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }

        //------------INSERT -----------
        static void InsertProduct()
        {
            try
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");

                    DataTable table = ds.Tables["Products"];

                    DataRow row = table.NewRow();
                    row["ProductName"] = name;
                    row["Category"] = category;
                    row["Price"] = price;

                    table.Rows.Add(row);

                    adapter.Update(ds, "Products");

                    Console.WriteLine("Inserted Successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // --------------- VIEW ---------------
        static void ViewProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");

                    Console.WriteLine("\n--- PRODUCT LIST ---");

                    foreach (DataRow row in ds.Tables["Products"].Rows)
                    {
                        Console.WriteLine($"ID: {row["ProductId"]}, Name: {row["ProductName"]}, Category: {row["Category"]}, Price: {row["Price"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ------------ UPDATE ---------------
        static void UpdateProduct()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");

                    DataTable table = ds.Tables["Products"];

                    DataRow row = table.Select("ProductId=" + id).FirstOrDefault();

                    if (row != null)
                    {
                        Console.Write("New Name: ");
                        row["ProductName"] = Console.ReadLine();

                        Console.Write("New Category: ");
                        row["Category"] = Console.ReadLine();

                        Console.Write("New Price: ");
                        row["Price"] = decimal.Parse(Console.ReadLine());

                        adapter.Update(ds, "Products");

                        Console.WriteLine("Updated Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ----------  DELETE --------------
        static void DeleteProduct()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");

                    DataTable table = ds.Tables["Products"];

                    DataRow row = table.Select("ProductId=" + id).FirstOrDefault();

                    if (row != null)
                    {
                        row.Delete();

                        adapter.Update(ds, "Products");

                        Console.WriteLine("Deleted Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
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