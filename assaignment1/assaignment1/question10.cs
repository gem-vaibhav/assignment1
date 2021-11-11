using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question10
    {
        public static void solution10()
        {
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine(IsResultTheSame(s1, s2));
            }
             static bool IsResultTheSame(string x, string y)
            {
                return eval(x) == eval(y);

            }
                static double eval(string value)
            {

                string[] l = new string[2];
                if (value.Contains('+'))
                {
                    l = value.Split('+');
                    return Convert.ToDouble(l[0]) + Convert.ToDouble(l[1]);
                }
                else if (value.Contains('-'))
                {
                    l = value.Split('-');
                    return Convert.ToDouble(l[0]) - Convert.ToDouble(l[1]);
                }
                else if (value.Contains('*'))
                {
                    l = value.Split('*');
                    return Convert.ToDouble(l[0]) * Convert.ToDouble(l[1]);
                }
                else if (value.Contains('/'))
                {
                    l = value.Split('/');
                    return Convert.ToDouble(l[0]) / Convert.ToDouble(l[1]);
                }
                else
                {
                    l = value.Split('%');
                    return Convert.ToDouble(l[0]) % Convert.ToDouble(l[1]);
                }

            }
        }
    }
}
