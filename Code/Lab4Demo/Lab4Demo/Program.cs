using System;

namespace Lab4Demo
{
    class Program
    {
        static double Pow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            double y = Pow(x, n / 2);

            if (n % 2 == 0)
            {
                y = y * y;
            }
            else
            {
                y = y * y * x;
            }
            return y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("2 ^ 10 = {0}", Pow(2, 10));
        }
    }
}
