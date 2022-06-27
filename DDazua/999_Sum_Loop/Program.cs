using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1부터 100까지 더하는 프로그램
            // 1에서 100까지 홀수의 합을 구하는 프로그램
            // 1 + 1/2 + 1/3 + ... + 1/100(역수의 합)을 구하는 프로그램
            Console.WriteLine("1부터 100까지 더하는 프로그램");
            int i= 1;
            int sum = 0;
            do
            {
                sum += i;
                i++;
            } while (i <= 100);
            Console.WriteLine($"1부터 100까지 더하면 {sum}이다.");

            int i1 = 1;
            int sum1 = default;
            Console.WriteLine(sum1);
            while (i1 <= 100)    
            {
                sum1 += i1;
                i1++;
            }
            Console.WriteLine($"1부터 100까지 더하면 {sum1}이다.");
            int sum2 = 0;
            for (int i2 = 1; i2 < 101; i2++)
            {
                sum2 += i2;
            }
            Console.WriteLine($"1부터 100까지 더하면 {sum2}이다.");

            Console.WriteLine("x의 y승을 계산합니다.");
            Console.Write("x를 입력하세요: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y를 입력하세요: ");
            int y = int.Parse(Console.ReadLine());

            int pow = 1;
            for (int i3 = 0; i3 < y; i3++)
            {
                pow *= x;
            }
            Console.WriteLine($"{x}의 {y}승은 {pow}입니다.");
        }
    }
}
