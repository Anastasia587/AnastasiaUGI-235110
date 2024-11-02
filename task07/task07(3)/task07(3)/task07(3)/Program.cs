using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_3_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белой ладьи:");
            var whiteRookPosition = Console.ReadLine();

            if (!IsPositionValid(whiteRookPosition, out int whiteRookRow, out int whiteRookColumn))
            {
                Console.WriteLine("Некорректная позиция белой ладьи");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите позицию черной ладьи:");
            var blackRookPosition = Console.ReadLine();

            if (!IsPositionValid(blackRookPosition, out int blackRookRow, out int blackRookColumn))
            {
                Console.WriteLine("Некорректная позиция черной ладьи");
                Console.ReadKey();
                return;
            }

            if (whiteRookRow == blackRookRow && whiteRookColumn == blackRookColumn)
            {
                Console.WriteLine("Позиции белой и черной ладей не могут совпадать");
                Console.ReadKey();
                return;
            }

            if (IsRookAttacking(blackRookRow, blackRookColumn, whiteRookRow, whiteRookColumn))
            {
                Console.WriteLine("Позиции белой и черной ладей находятся под боем друг друга");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите ход белой ладьи:");
            var targetPosition = Console.ReadLine();

            if (!IsPositionValid(targetPosition, out int targetRow, out int targetColumn))
            {
                Console.WriteLine("Некорректная позиция для хода");
                Console.ReadKey();
                return;
            }

            if (IsRookMoveValid(whiteRookRow, whiteRookColumn, targetRow, targetColumn) &&
                !IsRookAttacking(blackRookRow, blackRookColumn, targetRow, targetColumn))
            {
              
                Console.WriteLine("Ход разрешен");
            }
            else
            {
                Console.WriteLine("Ход запрещен");
            }

            Console.ReadKey();
        }

        static bool IsPositionValid(string position, out int row, out int column)
        {
            row = 0;
            column = 0;

            char columnChar = position[0];
            char rowChar = position[1];

            if (columnChar < 'a' || columnChar > 'h') return false;
            if (rowChar < '1' || rowChar > '8') return false; 
            column = columnChar - 'a' + 1; 
            row = int.Parse(rowChar.ToString());

            return true;
        }

        static bool IsRookMoveValid(int rookRow, int rookColumn, int targetRow, int targetColumn)
        {
            return rookRow == targetRow || rookColumn == targetColumn;
        }

        static bool IsRookAttacking(int rookRow, int rookColumn, int targetRow, int targetColumn)
        {
            return rookRow == targetRow || rookColumn == targetColumn;
        }
    }
}
