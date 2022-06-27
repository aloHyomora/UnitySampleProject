using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_MISSION1
{
    internal class Program               //
    {
        //파라미터, 리턴  

        static bool ResultIF(char op,int num1, int num2)
        {
            int total = 0;
            if (num1 != 0 && num2 != 0)
            {
                if (op == '+' || op == '-' || op == '*' || op == '/')
                {
                    if (op == '+')
                    {
                        total = num1 + num2;
                    }
                    else if (op == '-')
                    {
                        total = num1 - num2;
                    }
                    else if (op == '*')
                    {
                        total = num1 * num2;
                    }
                    else
                    {
                        total = num1 / num2;
                    }
                    Console.WriteLine($"IF연산 결과: \t{num1} {op} {num2} = {total}");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        static bool ResultSwitch(char op, int num1, int num2)
        {
            int total = 0;
            if (num2 != 0 && num2 != 0)
            {
                if (op == '+' || op == '-' || op == '*' || op == '/')
                {
                    switch (op)
                    {
                        case '+':
                            total = num1 + num2;
                            break;
                        case '-':
                            total = num1 - num2;
                            break;
                        case '*':
                            total = num1 * num2;
                            break;
                        case '/':
                            total = num1 / num2;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine($"switch연산 결과: \t{num1} {op} {num2} = {total}");

                    return true;
                }
                else
                {
                    return false;
                }
            }return false;
        }


        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0, total = 0;
            char op;

            do
            {
                Console.WriteLine("심플 계산기");

                Console.Write("첫번째 수 입력: ");
                num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("덧셈(+), 뺄셈(-), 곱셈(*), 나눗셈(/)중 하나 선택: ");
                op = Console.ReadKey().KeyChar;

                Console.Write("\n두번째 수를 입력: ");
                num2 = int.Parse(Console.ReadLine());

                bool isIF=ResultIF(op, num1, num2);
                bool isSwitch=ResultSwitch(op, num1, num2);

                if(isIF==false||!isSwitch)                    
                    {
                        Console.WriteLine("연산자 입력 오류!!");
                    }
                
            } while (num1 != 0 && num2 != 0);
        }
    }
}
