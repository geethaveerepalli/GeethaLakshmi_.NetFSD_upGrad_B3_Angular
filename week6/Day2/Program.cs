using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

             string connStr = config.GetConnectionString("DefaultConnection");

            while (true)
                {
                    Console.WriteLine("\n--- PRODUCT MENU----");
                    Console.WriteLine("1. Insert");
                    Console.WriteLine("2. View");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter choice: ");

             int choice = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connStr)){

            conn.Open();

            try{
            if (choice == 1){
             Console.Write("Name: ");
             string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", name);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Price", price);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Successfully!");
            }
            else if (choice == 2)
            {
            SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- Product List ---");

            while (reader.Read())
            {
                    Console.WriteLine("ID   : " + reader["ProductId"]);
                    Console.WriteLine("Name : " + reader["ProductName"]);
                    Console.WriteLine("Cat  : " + reader["Category"]);
                    Console.WriteLine("Price: " + reader["Price"]);
                    Console.WriteLine();
            }

            reader.Close(); 
            }
            else if (choice == 3)
                            {
            Console.Write("Enter ID: ");
           int id = Convert.ToInt32(Console.ReadLine());

             Console.Write("New Name: ");
             string name = Console.ReadLine();

            Console.Write("New Category: ");
            string category = Console.ReadLine();

            Console.Write("New Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@ProductName", name);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Price", price);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated Successfully!");
            }
            else if (choice == 4)
            {
               Console.Write("Enter ID to delete: ");
               int id = Convert.ToInt32(Console.ReadLine());

               SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
               cmd.CommandType = System.Data.CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@ProductId", id);

               cmd.ExecuteNonQuery();
               Console.WriteLine("Deleted Successfully!");
            }
            else if (choice == 5)
            {
                   Console.WriteLine("Exiting...");
                   break;
            }
            else
             {
                  Console.WriteLine("Invalid choice!");
            }
               }
            catch (Exception ex)
            {
                 Console.WriteLine("Error: " + ex.Message);
            }
            }
        }
        }
   }
}
