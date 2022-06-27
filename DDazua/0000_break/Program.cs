using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0000_break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    Console.Write(" ");
                }
                int loopone = 7 - (i * 2);
                for (int j = 0; j < loopone; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();    
            }
            for (int i = 1; i < 5; i++)
            {
                for (int k = 0; k < (4-i); k++) //3  2  1 (4-i)
                {
                    Console.Write(" ");
                }
                int loopone = 2 * i - 1;
                for (int j = 0; j < loopone; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            
        }
    }
}
