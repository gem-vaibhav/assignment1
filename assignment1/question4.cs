using System;

namespace question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number=");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number=");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((num1 >= -10 && num1 <= 10) || (num2 >= -10 && num2 <= 10) ? true : false);
        }
    }
}
