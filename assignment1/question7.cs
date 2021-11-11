using System;

namespace question7
{
    class Program
    {
        static void Main(string[] args)
        {
            char first_letter, second_letter, third_letter;
            first_letter = Console.ReadLine()[0];
            second_letter = Console.ReadLine()[0];
            third_letter = Console.ReadLine()[0];
            Console.WriteLine($"{third_letter} {second_letter} {first_letter}");
        }
    }
}
