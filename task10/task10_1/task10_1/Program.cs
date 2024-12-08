using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;

            if (!TryInputNumber("Введите число a < 500):", out a) || a >= 500)
            {
                Console.WriteLine("Значение a должно быть меньше 500");
                Console.ReadKey();
                return;
            }

            long sumOfCubes = 0;

            for (var i = a; i <= 500; i++)
            {
                sumOfCubes += (long)Math.Pow(i, 3);
            }

            Console.WriteLine($"Сумма кубов чисел от {a} до 500 равна {sumOfCubes}");
            Console.ReadKey();
        }

        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Введите целое число.");
                return false;
            }

            return true;
        }
    }
}
