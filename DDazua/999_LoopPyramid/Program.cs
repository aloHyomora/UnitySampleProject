using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPyramid
{
    internal class Program
    {
        static void Main(string[] args) // 피라미드 출력 반복문
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i+1; j++)                
                    Console.Write("*");                
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 5; i >0 ; i--)
            {
                for (int j = 0; j < i; j++)                
                    Console.Write('*');
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 1; i <=5 ; i++)
            {
                for (int j = 0; j < 5-i; j++)                
                    Console.Write(" ");
                for (int j = 0; j < i; j++)
                    Console.Write("*");
                Console.WriteLine();                
            }
            Console.WriteLine();

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < 5-i; j++)                
                    Console.Write(" ");
                for (int j = 0; j < 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 5; i > 0; i--)
            {
                for (int j = 0; j < 5 - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
