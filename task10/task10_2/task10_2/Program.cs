using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            if (!TryInputNumber("Введите количество чисел n:", out n))
            {
                Console.ReadKey();
                return;
            }

            if (n < 1)
            {
                Console.WriteLine("Количество чисел должно быть больше 0");
                Console.ReadKey();
                return;
            }

            double sum = 0;

            for (var i = 0; i < n; i++)
            {
                double number;
                if (!TryInputDouble($"Введите {i + 1}-е число:", out number))
                {
                    Console.ReadKey();
                    return;
                }

                sum += Math.Abs(number);
            }

            Console.WriteLine($"Сумма модулей введённых чисел: {sum}");

            Console.ReadKey();
        }

        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Введите целое число");
                return false;
            }

            return true;
        }

        static bool TryInputDouble(string message, out double number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!double.TryParse(input, out number))
            {
                Console.WriteLine("Введите действительное число");
                return false;
            }

            return true;
        }
    }
}