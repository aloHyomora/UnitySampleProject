using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 3, 5, 2, 7, 1 };
            PrintArray("버블정렬", v);

            for (int i = v.Length-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (v[j]>v[j+1])
                    {
                        int t = v[j + 1];
                        v[j+1]=v[j];
                        v[j] = t;
                    }                    
                }
                PrintArray("배열 고정", v);
            }
        }
        static void PrintArray(string s, int[] v)
        {
            Console.WriteLine(s);
            foreach (var item in v)
                Console.Write("{0,5}", item);
            Console.WriteLine();
        }
    }
}
