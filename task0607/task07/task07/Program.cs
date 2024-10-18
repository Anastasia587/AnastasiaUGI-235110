using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "теплоход";
            Console.WriteLine($"Из слова \"{s}\" получили");

            var word1 = s
                .Remove(0, 3)
                .Substring(2, 2) +
                s.Substring(3, 2) +
                s.Substring(7, 1)

                ;
            Console.WriteLine(word1);


            var word2 = s
                .Substring(7, 1) +
                s.Remove(0,1)
                .Remove(1,1)
                .Remove(3, 3)
                ;

            Console.WriteLine(word2);
            Console.ReadKey();

        }

        static string ReverseString(string s)
        {
            return new string (s.Reverse().ToArray());
        }
    }
}
