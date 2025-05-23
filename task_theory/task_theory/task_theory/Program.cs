using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_theory
{
    internal class Program
    {
        static void Main()
        {
            // Декларация массива
            int[] numbers;

            // Инициализация массива с фиксированным размером
            numbers = new int[5];
            //Инициализация с присвоением значений
            int[] numbers = new int[] {1,2,3,4,5};
            //Упрощенная инициализация
            int[] numbers = {1,2,3,4,5};
            //Неявная инициализация
            var numbers = new[] { 1, 2, 3, 4, 5 };

            //Индексы элементов массива
            int firstElement = numbers[0];

            // Присвоение значений элементам массива
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;
            // Изменение значения элемента массива
            numbers[0] = 20;

            // Вывод значений элементов массива
            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Элемент с индексом {i}: {numbers[i]}");
            }
            
            // Пример с типом string
            string[] fruits = { "Яблоко", "Киви", "Груша" };

            // Вывод элементов массива типа string
            Console.WriteLine("\nФрукты:");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine($"Фрукт с индексом {i}: {fruits[i]}");
            }

            // Изменение значения элемента массива типа string
            fruits[1] = "Апельсин";
            Console.WriteLine("\nОбновленный массив фруктов:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
            Console.ReadLine();
        }
    }
}
 