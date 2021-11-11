using System;

namespace question5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number=");
            long number1 = Convert.ToInt64(Console.ReadLine());
            Console.Write("Eenter second number=");
            long number2= Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(number1 == number2 ? 6 * number1 : number1 + number2);
        }
    }
}
