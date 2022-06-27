using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _039_Method_delegate  //대리자
{
    internal class Program
    {
        delegate void DelegatePrint();  //  {}가 없는 형태, 사용자가 직접 만든 함수
                                       //void에 파라미터가 없는 레퍼런싱할수있는 함수

        static void PrintHello()
        {
            Console.WriteLine("Print Hello");
        }

        static void PrintValue()
        {
            Console.WriteLine("Print Value");
        }


        delegate void DelegatePrintSum(int a, int b);
        static void PrintSum(int a,int b)
        {
            Console.WriteLine($"PrintSUm : {a + b}");
        }

        static void TestDelegate(int a, int b, DelegatePrintSum dSum)
        {
            Console.WriteLine($"a: " + a + " b: " + b);

            if (dSum != null)
            {
                Console.WriteLine("TestDelegate: " );

                dSum(a, b);
            }
        }




        static void Main(string[] args)
        {
            { //int num 처럼 비슷한 형태,   delegate 함수를 변수처럼 사용?? 
                DelegatePrint dPrint = null;
                dPrint = PrintHello;  //dprint가 PrintHello를 레퍼런싱하고있다.

                dPrint();     //대리자가 대신 레퍼런싱가능
                PrintHello();

                dPrint = PrintValue;  //다시 PrintValue를 레퍼런싱하라고 했기 때문에
                dPrint();
            }

            {
                Console.WriteLine();
                Console.WriteLine("대리자의 멀티 캐스트  += ");  //함수를 dPrint안에 계속 입력가능 유용함.
                DelegatePrint dPrint1 = PrintHello;
                dPrint1 += PrintValue;
                dPrint1 += PrintHello;
                dPrint1();
                Console.WriteLine();

                Console.WriteLine("대리자의 멀티 캐스트  -= ");
                dPrint1 -= PrintValue;
                dPrint1();
                Console.WriteLine();

            }

            {
                Console.WriteLine("대리자의 combine");
                DelegatePrint combineDelegate = (DelegatePrint)Delegate.Combine(new DelegatePrint[] { PrintHello, PrintValue, PrintHello });
                combineDelegate();
                Console.WriteLine();

                Console.WriteLine("대리자의 combine2");
                DelegatePrint aa = PrintHello;
                DelegatePrint bb = PrintValue;
                DelegatePrint cc = PrintHello;

                DelegatePrint combineDelegate2=(DelegatePrint)Delegate.Combine(aa, bb, cc); //var로 받을수 없다.
                combineDelegate2();                                            //var은 변수를 받는 것

                Console.WriteLine("대리자의 combine2");
                DelegatePrint combineDelegate3=(DelegatePrint)Delegate.Remove(combineDelegate2, bb);
                combineDelegate3();
            }


            { //dPrint = PrintSum;  오류!!  dPrint는 위에서 처럼 void고 파라미터가 없는 형태만 받을 수 있다.
                DelegatePrintSum dPrintSum = PrintSum;  //그렇다면 파라미터를 포함한 delegate를 다시 만들어 준다.
                dPrintSum(10, 20);
                {
                    void Sum(int a, int b)          //이상하게 만들어짐 위아래로 함수호출~
                    {
                        Console.Write("Sum  "+(a + b));
                    }
                    TestDelegate(20, 40,Sum);
                }
            }
        }
    }
}
