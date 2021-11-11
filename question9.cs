using System;

namespace question9
{
    class Program
    {
        static void Main(string[] args)
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
