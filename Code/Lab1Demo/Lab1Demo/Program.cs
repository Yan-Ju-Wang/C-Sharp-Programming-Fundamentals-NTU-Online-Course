using System;

namespace Lab1Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rng = new Random();
            int s = rng.Next(100);
            int low = 0, high = 99; // inclusive

            while (true)
            {
                Console.WriteLine("({0}, {1})?", low, high);
                int g = int.Parse(Console.ReadLine());

                if (g > high || g < low)
                {
                    Console.WriteLine("Out of range. Try again?");
                    continue;
                }

                if (g == s)
                {
                    Console.WriteLine("Bingo.");
                    break;
                }
                else if (g > s)
                {
                    Console.WriteLine("Too large.");
                    high = g - 1;
                }
                else
                {
                    Console.WriteLine("Too small.");
                    low = g + 1;
                }

                if (high == low)
                {
                    Console.WriteLine("Game over.");
                    break;
                }
            }

        }
    }
}
