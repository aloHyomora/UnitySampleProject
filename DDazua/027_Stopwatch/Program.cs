using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027_Stopwatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw= new System.Diagnostics.Stopwatch();
            sw.Start();

            int i = 0;
            for (; i < int.MaxValue; i++)
            {
                
                //Console.Write($"{i} ");
            }
            Console.Write($"{i} ");

            if (sw.IsRunning)
            {
                sw.Stop ();

                Console.WriteLine($"Time: {sw.ElapsedMilliseconds.ToString()  }ms");
                Console.WriteLine($"Time: {sw.Elapsed.ToString() }");
                Console.WriteLine("Time: {0:hh\\:mm\\:ss}",sw.Elapsed);
            }
        }
    }
}
