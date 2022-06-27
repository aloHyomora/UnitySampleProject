using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 5; i++)
            {
                //3 2 1

                for (int k = 0; k < (4 - i); k++)
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
