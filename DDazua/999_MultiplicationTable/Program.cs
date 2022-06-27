using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("구구단 몇단을 볼까요?(1~9) : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                Console.Write("{0} * {1} = {2}  ", n, i, n * i);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("구구단 2 ~ 9단을 볼까요? 보고싶으면 1을 입력하세요(다른 입력시 종료)");
            int  input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                for (int i = 2; i <=9 ; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        Console.Write("{0}*{1} = {2,2} ",i,j,i*j);                        
                    }
                    Console.WriteLine();
                }
            }
            else return;
        }
    }
}
