using System;

namespace Lab5App
{
    abstract class Player
    {
        public abstract int Next(int low, int high);
    }

    class NaiveAI : Player
    {
        public override int Next(int low, int high)
        {
            return new Random().Next(low, high + 1);
        }
    }

    class BinarySearchAI : NaiveAI
    {
        public override int Next(int low, int high)
        {
            return (low + high) / 2;
        }
    }

    class SuperAI : NaiveAI
    {
        public override int Next(int low, int high)
        {
            return low;
        }
    }

    class HumanPlayer : Player
    {
        public override int Next(int low, int high)
        {
            int g = int.Parse(Console.ReadLine());
            return g;
        }
    }
    class Game
    {
        int s;
        int low = 0, high = 99;
        Player player;
        bool win = false;

        public Game(Player player)
        {
            Random rng = new Random();
            s = rng.Next(100);
            this.player = player;
        }

        public bool hasWon()
        {
            return win;
        }

        public void Run()
        {
            while (true)
            {
                int g = player.Next(low, high);
                if (g == s)
                {
                    win = true;
                    break;
                }
                else if (g > s) high = g - 1;
                else low = g + 1;
                if (high == low) break;   
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new SuperAI();
            int N = 100000;
            int wins = 0;
            for (int i = 1; i <= N; i++)
            {
                Game game = new Game(player);
                game.Run();
                if (game.hasWon())
                    wins++;
            }
            Console.WriteLine("Winning rate = {0}%", 100.0 * wins / N);

        }
    }
}
