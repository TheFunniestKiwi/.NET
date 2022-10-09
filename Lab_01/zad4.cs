using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    public  class zad4
    {
        private readonly int Min = 1, Max;
        public zad4(int max)=> Max = max;
        private int attempts = 0;
        private Random rand = new Random();
        int guess;


        public int run()
        {
            game();
            ranking();
            return attempts;
        }
        private void game()
        {
            Console.WriteLine("Guess a number from ");
            var value = rand.Next(Min, Max);
            guess = Convert.ToInt32(Console.ReadLine());

            while (guess != value)
            {
                if (guess > value)
                {
                    Console.WriteLine("Less");
                    attempts++;
                }
                else if (guess < value)
                {
                    Console.WriteLine("More");
                    attempts++;
                }
                    
                    
                guess = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("You win");
        }

        private void ranking()
        {
            Console.WriteLine("Ranking");
            Console.WriteLine($"Your won in {attempts} attempts");
        }

        
        
    }
}
