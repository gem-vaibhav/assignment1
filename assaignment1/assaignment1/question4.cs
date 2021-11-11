using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question4
    {
        public static void solution4()
        {
            Console.Write("Enter first number=");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number=");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((num1 >= -10 && num1 <= 10) || (num2 >= -10 && num2 <= 10) ? true : false);
        }
    }
}
