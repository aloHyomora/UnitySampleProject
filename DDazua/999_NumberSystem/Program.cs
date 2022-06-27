using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_NumberSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,5} {1,8} {2,4} {3,4}", "10진수", "2진수", "8진수", "16진수");

            for (int i = 0; i <= 128; i++)
            {
                Console.WriteLine("{0,7} {1,10} {2,5} {3,6}",
                    i,
                    Convert.ToString(i, 2).PadLeft(8, '0'), // i를 2진수 문자열로 바꿈
                    Convert.ToString(i, 8),
                    Convert.ToString(i, 16)
                    );
            }
        }
    }
}
