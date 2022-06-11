using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Output: ");
            Console.WriteLine(12 * 12 == PrintProduct("12", "12"));
            Console.WriteLine(571 * 12 == PrintProduct("571", "12"));
            Console.WriteLine(5 * 2 == PrintProduct("5", "2"));
            Console.WriteLine(5 * 0 == PrintProduct("5", "0"));
            Console.WriteLine(0 * 10 == PrintProduct("0", "10"));
            Console.WriteLine(3510 * 90220 == PrintProduct("3510", "90220"));
            Console.ReadLine();

            /*
             * Output:
             * True
             * True
             * True
             * True
             * True
             * True
             */
        }

        /*
         * Solved this by spliting the multiplier into multiple of pow(10)
         * for example
         * 571 * 12 => (1*12) + (70*12) + (500*12)
         * 12 * 12 => (2*12) + (10*12)
         */
        private static int PrintProduct(string x, string y)
        {
            (x, y) = x.Length > y.Length ? (x, y) : (y, x);
            var yrr = new int[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                int divisor = Convert.ToInt32(Math.Pow(10, i + 1));
                int remainder = (int.Parse(x) % divisor) - yrr.Sum();
                yrr[i] = remainder;
            }
            int sum = yrr.Sum(c => c * int.Parse(y));
            return sum;
        }
    }
}
