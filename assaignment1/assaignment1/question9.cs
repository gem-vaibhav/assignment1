using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question9
    {
        public static void solution9()
        {
            string str = Console.ReadLine();
            Console.WriteLine(Hasletter(str));
        }
        public static bool Hasletter(string str)
        {
            int tmp = -1;

            for (int i = 0; i < str.Length; i++)
            {
                tmp = str[i];
                if (tmp >= 48 && tmp <= 57)
                {
                    return false;
                }
            }

            return true;
        }
    }
    }
