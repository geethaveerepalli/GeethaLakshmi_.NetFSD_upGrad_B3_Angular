namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int i = 1;
            int even = 0, odd = 0, sum = 0;

            Console.Write("Enter Number: ");
            n = int.Parse(Console.ReadLine());

            while (i <= n)
            {
                sum += i;

                if (i % 2 == 0)
                    even++;
                else
                    odd++;

                i++;
            }

            Console.WriteLine($"Even Count: {even}");
            Console.WriteLine($"Odd Count: {odd}");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
