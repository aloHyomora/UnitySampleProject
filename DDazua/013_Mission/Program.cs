using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Mission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            {
                int[] number = { 72, 69, 76, 79, 82, 87, 68, 32 };
                Array.Sort(number);

                Console.Write("Sort: ");

                for (int i = 0; i < number.Length; i++)
                {
                    Console.Write($"{(char)number[i]} ");
                }

                char h=(char)(number[3]);
                char e = (char)(number[2]);
                char l = (char)(number[4]);
                char o = (char)(number[5]);
                char w = (char)(number[7]);
                char r = (char)(number[6]);
                char d = (char)(number[1]);
                char space = (char)(number[0]);

                Console.WriteLine();
                int[] Helloindex = { 3, 2, 4, 4, 5, 0, 7, 5, 6, 4, 1 };
                for (int i  = 0; i < Helloindex.Length; i++)
                {
                    Console.Write($"{(char)number[Helloindex[i]]}");
                }

            }
        }
    }
}

