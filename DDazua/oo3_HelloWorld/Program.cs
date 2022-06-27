using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oo3_HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //변수 선언에 기초 방법  주석은 컴파일하지 않아요~
            { 
                int number;
                number = 10;
                Console.WriteLine("number: " + number); //예약어는 식별자(변수의 이름)으로 사용불가
            }
            /*요건 블록 주석*/
            
            {
                int x;
                int a,b,c;

                int xx = 100; //변수 선언과 동시에 초기화 가능하면 디폴트값을 주는게 아니면 쓰레기값이 들어감
            }

            //값 형식은 스택(Stack)에 할당 {}를 벗어나면 해제
            //참조 형식은 

        }
    }
}
