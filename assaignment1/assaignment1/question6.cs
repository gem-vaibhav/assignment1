using System;
using System.Collections.Generic;
using System.Text;

namespace assaignment1
{
    class question6
    {
        public static void solution6()
        {
            int count = 0;
            while (count != 3)
            {
                Console.Write("Enter username=");
                string username = Console.ReadLine();
                Console.Write("Enter password=");
                string password = Console.ReadLine();

                if (username == "username" && password == "password")
                {
                    Console.WriteLine("Login successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong attempt , try again");
                    count++;
                }
            }
            if (count == 3)
                Console.WriteLine("Access rejected");
        }
    }
 }