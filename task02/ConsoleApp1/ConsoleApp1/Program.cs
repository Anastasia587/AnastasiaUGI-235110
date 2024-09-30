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
            Console.WriteLine();
            Console.WriteLine("Введите длину 1-ой стороны прям.параллелепипеда (в см)");
            var a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите длину 2-ой стороны прям.параллелепипеда (в см)");
            var b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите длину 3-ей стороны прям.параллелепипеда (в см)");
            var c = double.Parse(Console.ReadLine());

            var V = a * b * c;
            Console.WriteLine("Объем прямоуг.параллелепипеда: " +  V + " куб.см ");

            var P = 2 * (a * b + a * c + b * c);
            Console.WriteLine("Площадь поверхности прямоуг.параллелепипеда: " + P + " кв.см ");

            Console.ReadKey();
        }
    }
}
