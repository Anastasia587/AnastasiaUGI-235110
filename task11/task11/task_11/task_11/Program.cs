using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное целое число n:");
            if (!long.TryParse(Console.ReadLine(), out long n) || n <= 0)
            {
                Console.WriteLine("Неверный ввод");
                Console.ReadKey();
                return;
            }

            var reversedDigits = ExtractReversedDigits(n);
            DisplayArray(reversedDigits);

            Console.WriteLine("Введите значение k:");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("Неверный ввод");
                Console.ReadKey();
                return;
            }

            UpdateArray(ref reversedDigits, k);
            DisplayArray(reversedDigits);

            int totalModule10 = CalculateSumModule10(reversedDigits);
            Console.WriteLine($"Сумма элементов массива по модулю 10: {totalModule10}");

            var swappedArray = ExchangeAdjacentElements(reversedDigits);
            Console.WriteLine("Массив после обмена соседних элементов:");
            DisplayArray(swappedArray);

            Console.ReadKey();
        }

        static int[] ExtractReversedDigits(long value)
        {
            var digitList = new List<int>();
            while (value > 0)
            {
                digitList.Add((int)(value % 10));
                value = value / 10;
            }
            return digitList.ToArray();
        }

        static void DisplayArray(int[] array)
        {
            Console.WriteLine(string.Join(";", array));
            Console.WriteLine();
        }

        static void UpdateArray(ref int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array[i] + k) % 10;
            }
        }

        static int CalculateSumModule10(int[] array)
        {
            int total = 0;
            foreach (var item in array)
            {
                total = (total + item) % 10;
            }
            return total;
        }

        static int[] ExchangeAdjacentElements(int[] array)
        {
            int[] modifiedArray = (int[])array.Clone();
            for (int i = 0; i < modifiedArray.Length - 1; i += 2)
            {
                int temp = modifiedArray[i];
                modifiedArray[i] = modifiedArray[i + 1];
                modifiedArray[i + 1] = temp;
            }
            return modifiedArray;
        }
    }
}