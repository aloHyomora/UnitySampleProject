using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _038_Method_local
{
    internal class Program
    {
        public static int Sum(int a, int b)        //함수 내에 함수가 존재 local함수
        {
            PrintInput();
            return a + b;

            void PrintInput()                       //local함수는 접근지정자 사용불가! (private
            {
                Console.WriteLine($"입력1: {a} 입력2: {b}");
            }
        }

        public static void LocalPrint(int num)
        {
            switch (num)
            {
                case 1:
                    PrintNum();
                    break;
                case 100:
                    PrintNum();
                    break;

                default:
                    PrintNum();
                    break;
            }

            void PrintNum()      //local함수 
            {
                Console.WriteLine($"입력: {num}");
            }
        }

        static void Main(string[] args)    
        {
            Sum(10, 20);
            LocalPrint(100);
            LocalPrint(1);
            LocalPrint(999);

            PrintHelloWorld();

            void PrintHelloWorld()    //main함수에서도 local함수가 적용될까? 가능하다
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
