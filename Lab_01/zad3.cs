using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    public static class zad3
    {
        public static void FizzBuzz(int N)
        {
            WriteLine("FizzBuzz");
            bool skip;
            for (int i = 0; i <= N; i++)
            {
                skip = false;
                if (i % 3 == 0) { WriteLine("Fizz"); skip = true; }
                if (i % 5 == 0) { WriteLine("Buzz"); skip = true; }
                WriteLine(skip ? "" : i);
            }
        }
    }
}
