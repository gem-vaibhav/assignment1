using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question5
    {
        public static void solution5()
        {
            Console.Write("Enter first number=");
            long number1 = Convert.ToInt64(Console.ReadLine());
            Console.Write("Eenter second number=");
            long number2 = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(number1 == number2 ? 6 * number1 : number1 + number2);
        }
    }
}
