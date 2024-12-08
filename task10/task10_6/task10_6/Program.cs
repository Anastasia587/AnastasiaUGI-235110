using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество групп n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество студентов в каждой группе m: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите количество экзаменов k: ");
            int k = int.Parse(Console.ReadLine());

            double bestAverage = 0;
            int bestGroup = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Ввод оценок для группы {i}:");
                double groupSum = 0;

                for (int j = 1; j <= m; j++)
                {
                    Console.WriteLine($"Студент {j}:");
                    double studentSum = 0;

                    for (int exam = 1; exam <= k; exam++)
                    {
                        Console.Write($"  Экзамен {exam}: ");
                        studentSum += double.Parse(Console.ReadLine());
                    }

                    groupSum += studentSum / k;
                }

                double groupAverage = groupSum / m;

                Console.WriteLine($"Средний балл группы {i}: {groupAverage:F2}");

                if (groupAverage > bestAverage)
                {
                    bestAverage = groupAverage;
                    bestGroup = i;
                }
            }

            Console.WriteLine($"Лучшая группа: {bestGroup} со средним баллом {bestAverage:F2}");
            Console.ReadKey();
        }
    }
}