using System;
namespace question10
{
    class Program
    {
        static void Main(string[] args)
        { string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine(IsResultTheSame(s1, s2));
        }
        public static bool IsResultTheSame(string x, string y)
        {
            return eval(x) == eval(y);
            
        }
        public static double eval(string value)
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
