using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение x: ");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x}) = {LogFunction(x)}");

            Console.ReadKey();
        }
        static double LogFunction(double x)
        {
            if (x > 1)
                return Math.Log(x);
            else if (x > 0 && x <= 1)
                return -Math.Log(x);
            else
                return 0; 
        }
    }
}
