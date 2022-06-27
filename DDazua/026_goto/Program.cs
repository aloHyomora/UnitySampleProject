using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_goto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 100;

            switch (num)
            {
                case 10:
                    Console.WriteLine($"goto num: {num}");
                    break;

                case 100:
                    goto case 10;
                default:
                    break;
            }
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write($"i: {i}");

                    if (i==10)
                    {
                        goto Finish;
                    }

                }
            Finish:
                Console.WriteLine("\n Finish~");
            }
        }
    }
}
