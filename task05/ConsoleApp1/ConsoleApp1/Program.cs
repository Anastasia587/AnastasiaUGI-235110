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
            var x = F(2,3) + F(3, 5) + F(5, 7);

            Console.WriteLine($"x = {x:F3}");

            Console.ReadKey();
        
        }
        static double F(double a, double b)
        {
            return Math.Sqrt((a + Math.Exp(-a))/b);
     
        }
    }
}
