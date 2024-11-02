using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = GetNumber("k");
            var m = GetNumber("m");
            var n = GetNumber("n");

            if (IsStatementTrue(k, m, n))
                Console.WriteLine("Утверждение истинно");
            else
                Console.WriteLine("Утверждение ложно");
            Console.ReadKey();


        }

            static bool IsStatementTrue(int k, int m, int n)
        { 
            return k % 3 == 0 && m % 3 == 0 && n % 3 == 0;
        }

        static int GetNumber(string numberName)
        {
            Console.WriteLine($"Введите  число {numberName}");
            return int.Parse(Console.ReadLine()) ;

        }
    }
}
