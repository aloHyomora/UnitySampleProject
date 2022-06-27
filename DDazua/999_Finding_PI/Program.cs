using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_Finding_PI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool plagsign = false;
            double PI = 0;

            for (int i = 1; i <= 10000; i+=2)
            {
                if(plagsign == false)
                {
                    PI += 1.0 / i;
                    plagsign = true;
                }
                else
                {
                    PI -= 1.0 / i;
                    plagsign = false;
                }
                Console.WriteLine("i = {0}, PI = {1}",i,4*PI);
            }

            // 합계가 10000이 넘는 순간 : 무한루프
            int sum = 0;
            for (int i = 1; ; i++)
            {
                sum += i;
                if(sum >= 10000)
                {
                    Console.WriteLine("1~{0}까지의 합 = {1}",i,sum);
                    break;
                }
            }
        }
    }
}
