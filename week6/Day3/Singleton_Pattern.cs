using System;

namespace Singleton_ConfigurationManager
{
    //Singleton Class
    public class ConfigurationManager
    {
        // Private static variable to hold single instance
        private static ConfigurationManager _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();

        // Configuration properties
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
        public string DatabaseConnectionString { get; private set; }

        // Private constructor prevents external instantiation
        private ConfigurationManager()
        {
            // Initialize default configuration
            ApplicationName = "Inventory Management System";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;Trusted_Connection=True;";
        }

        // 3. Public method to get single instance (thread-safe)
        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Lock ensures only one thread can create instance
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }

        // Method to display configuration
        public void ShowConfiguration()
        {
            Console.WriteLine("Application Name: " + ApplicationName);
            Console.WriteLine("Version: " + Version);
            Console.WriteLine("Database Connection: " + DatabaseConnectionString);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Get singleton instance multiple times
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            // Show configuration
            Console.WriteLine("Configuration from first instance:");
            config1.ShowConfiguration();

            Console.WriteLine("\nConfiguration from second instance:");
            config2.ShowConfiguration();

            // Verify both instances are the same
            if (object.ReferenceEquals(config1, config2))
            {
                Console.WriteLine("\nBoth instances are the SAME (Singleton works!)");
            }
            else
            {
                Console.WriteLine("\nDifferent instances (Singleton failed!)");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}