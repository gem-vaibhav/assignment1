using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question3
    {
        public static void solution3()
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
