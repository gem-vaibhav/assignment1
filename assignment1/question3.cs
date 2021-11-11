using System;

namespace question3
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = Convert.ToDouble(Console.ReadLine());
            double number2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Before\nFirst number={0}\tSecond number={1}", number1, number2);
            number1 = number1 + number2;
            number2 = number1 - number2;
            number1 = number1 - number2;
            Console.WriteLine("After\nFirst number={0}\tSecond number={1}", number1, number2);

        }
    }
}
