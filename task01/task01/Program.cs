using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Парус");

            Console.WriteLine();

            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Белеет парус одинокой");
            Console.WriteLine("В тумане моря голубом!..");
            Console.WriteLine("Что ищет он в стране далекой?");
            Console.WriteLine("Что кинул он в краю родном?..");

            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
