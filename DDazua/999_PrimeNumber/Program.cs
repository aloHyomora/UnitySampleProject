using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,10}", "소수 판별기");
            Console.WriteLine("숫자를 입력하세요");
            int PrimeNumber = int.Parse(Console.ReadLine());

            int i;
            for (i = 2; i < PrimeNumber; i++)
            {
                if(PrimeNumber % i == 0)
                {
                    Console.WriteLine("{0}은 소수가 아닙니다.",PrimeNumber);
                    break;
                }
            }
            if (i == PrimeNumber)
                Console.WriteLine($"{PrimeNumber}은 소수입니다.");
        }
    }
}
