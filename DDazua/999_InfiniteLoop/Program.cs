using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 첫 날 1000원을 저금하고 매일 전 날의 두 배씩을 저금한다고 하면 며칠 만에 100만원을 저금 할 수 있을 지 계산하는 프로그램을 
            // while 문과 for 문으로 만든다.

            int day=1;
            int money = 1000;
            int sum = 0;

            while (true)
            {
                sum += money;
                Console.WriteLine($"{day,2}일차 : {money,10:C},   sum = {sum,10:C}");
                if (sum>1000000)
                {
                    break;
                }
                day++;
                money *= 2;
            }
            Console.WriteLine($"{day}일차에 {sum,0:###,###}원이 된다. "); //{sum,0:###,###}으로도 출력됨. 앞의 0~3다른숫자도 다 출력 0이 가지는 의미?
            Console.WriteLine("{0}일차에 {1:###,###}원이 됩니다!", day, sum);
            Console.WriteLine();

            for (day=1, sum=0, money =1000;sum<1000000 ;day++,money *=2)
            {
                sum += money;
                Console.WriteLine($"{day,2}일차 : {money,10:C},   sum = {sum,10:C}");
            }
            Console.WriteLine("{0}일차에 {1:###,###}원이 됩니다!", day-1, sum); // 무한루프 종료전에 day++실행 -> day-1

            // 1000까지의 소수를 출력하고 몇 개인지 출력
            int index;
            int primes = 0;
            for(int i = 2; i <= 1000; i++)
            {
                for (index = 2;  index < i; index++)
                {
                    if (i % index == 0) break;
                }
                if (i == index)
                {
                    primes++;
                    Console.Write("{0,5}{1}", index, primes % 15 == 0 ? "\n" : "");
                }
            }
            Console.WriteLine($"\n 2 ~ 1000까지 소수의 개수 : {primes}");
        }
    }
}
