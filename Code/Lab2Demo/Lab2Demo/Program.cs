using System;

namespace Lab2Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 16;
            int[] id = new int[N];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
            Random rng = new Random();
            for (int i = 0; i < id.Length; i++)
            {
                int j = rng.Next(0, id.Length - i) + i;
                int tmp = id[i];
                id[i] = id[j];
                id[j] = tmp;
            }
            Console.Write("{0, 9}", "ID");
            for (int i = 0; i < id.Length; i++)
            {
                Console.Write("{0, 3}", i);
            }
            Console.Write("\n{0, 9}", "Contactee");
            for (int i = 0; i < id.Length; i++)
            {
                Console.Write("{0, 3}", id[i]);
            }

            // main task

            Console.Write("\nThese citizens should be isolated: ");
            int target = 0;
            int curr = target;
            do
            {
                Console.Write("{0, 3}", curr);
                curr = id[curr];
            }
            while (curr != target);
            Console.WriteLine();
            
        }
    }
}
