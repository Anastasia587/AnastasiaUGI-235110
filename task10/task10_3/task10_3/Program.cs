using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Введите натуральное число n:");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка, введите натуральное число большее 0:");
            }

            Console.WriteLine($"Квадраты натуральных чисел, не превышающие {n}:");

            for (int i = 1; i * i <= n; i++)
            {
                Console.WriteLine($"{i}^2 = {i * i}");
            }

            Console.ReadKey();
        }
    }
}