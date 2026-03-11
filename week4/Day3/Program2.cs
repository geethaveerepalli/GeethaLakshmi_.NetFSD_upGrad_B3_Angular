namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, result = 0;
            char op;

            Console.Write("Enter First Number: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter Operator (+, -, *, /): ");
            op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Division by zero is not allowed");
                        return;
                    }
                    result = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Invalid Operator");
                    return;
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}
