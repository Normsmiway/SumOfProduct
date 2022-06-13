using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Output: ");
            Console.WriteLine();
            Console.WriteLine("Using Some of Product");
            Console.WriteLine(12 * 12 == PrintProduct("12", "12"));
            Console.WriteLine(571 * 12 == PrintProduct("571", "12"));
            Console.WriteLine(5 * 2 == PrintProduct("5", "2"));
            Console.WriteLine(5 * 0 == PrintProduct("5", "0"));
            Console.WriteLine(0 * 10 == PrintProduct("0", "10"));
            Console.WriteLine(3510 * 90220 == PrintProduct("3510", "90220"));
            Console.WriteLine();

            Console.WriteLine("Using Padded String Formular...");
            Console.WriteLine(129 * 13 == ProductOfStringPaddedStringFormular("129", "13"));
            Console.WriteLine(12 * 12 == ProductOfStringPaddedStringFormular("12", "12"));
            Console.WriteLine(571 * 12 == ProductOfStringPaddedStringFormular("571", "12"));
            Console.WriteLine(5 * 2 == ProductOfStringPaddedStringFormular("5", "2"));
            Console.WriteLine(5 * 0 == ProductOfStringPaddedStringFormular("5", "0"));
            Console.WriteLine(0 * 10 == ProductOfStringPaddedStringFormular("0", "10"));
            Console.WriteLine(3510 * 90220 == ProductOfStringPaddedStringFormular("3510", "90220"));
            Console.WriteLine(1510 * 30220 == ProductOfStringPaddedStringFormular("1510", "30220"));
            Console.WriteLine(415 * 322 == ProductOfStringPaddedStringFormular("322", "415"));

            Console.WriteLine();
            Console.WriteLine("Using Padded int Formular...");
            Console.WriteLine(129 * 13 == ProductOfStringPaddedIntFormular("129", "13"));
            Console.WriteLine(12 * 12 == ProductOfStringPaddedIntFormular("12", "12"));
            Console.WriteLine(571 * 12 == ProductOfStringPaddedIntFormular("571", "12"));
            Console.WriteLine(5 * 2 == ProductOfStringPaddedIntFormular("5", "2"));
            Console.WriteLine(5 * 0 == ProductOfStringPaddedIntFormular("5", "0"));
            Console.WriteLine(0 * 10 == ProductOfStringPaddedIntFormular("0", "10"));
            Console.WriteLine(3510 * 90220 == ProductOfStringPaddedIntFormular("3510", "90220"));
            Console.WriteLine(1510 * 30220 == ProductOfStringPaddedIntFormular("1510", "30220"));
            Console.WriteLine(415 * 322 == ProductOfStringPaddedStringFormular("322", "415"));

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
            int diff = 0, sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                int divisor = Convert.ToInt32(Math.Pow(10, i + 1));
                int remainder = (int.Parse(x) % divisor) - diff;
                diff += remainder;
                sum += remainder * int.Parse(y);
            }
            return sum;
        }//

        static int ProductOfStringPaddedStringFormular(string x, string y)
        {
            (x, y) = x.Length > y.Length ? (x, y) : (y, x);
            int sum = 0;
            int counter = 0;

            for (int i = y.Length - 1; i >= 0; i--)
            {
                int m = int.Parse(y[i].ToString());
                string product = (int.Parse(x) * m).ToString();
                product = product.PadRight(product.Length + counter, '0');
                sum += int.Parse(product);
                counter += 1;
            }
            return sum;
        }

        static int ProductOfStringPaddedIntFormular(string x, string y)
        {
            (x, y) = x.Length > y.Length ? (x, y) : (y, x);
            int sum = 0;
            int counter = 0;
            for (int i = y.Length - 1; i >= 0; i--)
            {
                int m = int.Parse(y[i].ToString());
                int product = (int.Parse(x) * m).PadRight(counter);
                sum += product;
                counter += 1;
            }
            return sum;
        }
    }

    public static class IntExtension
    {
        public static int PadRight(this int val, int value)
        {
            var pow = Convert.ToInt32(Math.Pow(10, value));
            return val * pow;
        }
    }
}
