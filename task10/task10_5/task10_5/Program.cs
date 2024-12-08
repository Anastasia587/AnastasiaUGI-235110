using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            int lcm = FindLCM(a, b);

            Console.WriteLine($"Наименьшее общее кратное чисел {a} и {b} равно {lcm}.");
            Console.ReadKey();
        }

        static int FindLCM(int x, int y)
        {
            int max = Math.Max(x, y);
            int lcm = max;

            while (true)
            {
                if (lcm % x == 0 && lcm % y == 0)
                {
                    break;
                }
                lcm++;
            }

            return lcm;
        }
    }
}