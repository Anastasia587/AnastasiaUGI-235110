using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число n: ");
            int n = int.Parse(Console.ReadLine());

            int k;

            while (true)
            {
                Console.Write("Введите число k (0 <= k <= 8): ");
                if (int.TryParse(Console.ReadLine(), out k) && k >= 0 && k <= 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка,введите число в диапазоне от 0 до 8 включительно");
                }
            }

            int sum = 0;

            while (n > 0)
            {
                int digit = n % 10;
                if (digit > k)
                    sum += digit;
                n /= 10;
            }

            Console.WriteLine($"Сумма цифр, больших {k}, равна {sum}");
            Console.ReadKey();
        }
    }
}