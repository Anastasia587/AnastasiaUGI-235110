using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Числа, равные сумме своих цифр, возведенных в степени 4, 5, 6 и 7:");

            for (int power = 4; power <= 7; power++)
            {
                Console.WriteLine($"\nРезультаты для степени {power}:");

                int totalSum = 0;

                for (int number = 10; number <= 10000000; number++) //программа долго работает даже при 100 млн, поэтому я оставила максимальное число 10000000
                {
                    if (IsSumOfPowers(number, power))
                    {
                        Console.WriteLine(number);
                        totalSum += number;
                    }
                }

                Console.WriteLine($"Сумма чисел для степени {power}: {totalSum}");
            }

            Console.ReadLine();
        }

        static bool IsSumOfPowers(int number, int power)
        {
            int sum = 0;
            int currentNumber = number;

            while (currentNumber > 0)
            {
                int digit = currentNumber % 10;
                sum += DigitPower(digit, power);
                currentNumber /= 10;
            }

            return sum == number;
        }

        static int DigitPower(int firstNumber, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= firstNumber;
            }
            return result;
        }
    }
}
