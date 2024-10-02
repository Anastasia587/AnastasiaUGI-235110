using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите чило от 1 до 999, чтобы число единиц не было равно нулю:");
            var number = int.Parse(Console.ReadLine());

            var units = number % 10;
            Console.WriteLine(units);
            int tens = (number % 100) / 10;
            Console.WriteLine(tens);
            var hundreds = number / 100;
            Console.WriteLine(hundreds);
            var result = (units * 100) + (tens * 10) + hundreds;
            
            Console.WriteLine("Число X: " + result);
            Console.ReadKey();



        }
    }
}
