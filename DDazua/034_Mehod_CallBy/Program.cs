using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034_Mehod_CallBy
{
    internal class Program
    {
        static public void SwapValue(int num1,int num2)  //static써야 main함수에서 사용가능
        {
            int temp = num1;  //num1, num2 값을 바꾸는 함수
            num1 = num2;
            num2 = temp;

            Console.Write("SwapValue: ");
            Print(num1, num2);
        }
        static public void SwapRef(ref int num1, ref int num2)
        {
            int temp = num1;  //num1, num2 값을 바꾸는 함수
            num1 = num2;
            num2 = temp;

            Console.Write("SwapRef: ");
            Print(num1, num2);
        }
        static public void Print(int num1,int num2)
        {
            Console.WriteLine($"num1: {num1} num2: {num2}");
        }

        public struct sData  //public을 안넣으면 private인 상태, 엑세스 불과 {} 밖에서 가져올경우 필수
        {
            public int _num1;
            public int _num2;

            public sData(int num1,int num2)  // 생성자
            {
                _num1 = num1;
                _num2 = num2;
            }
           
        }
        static void SwapStructValue(ref sData s1, ref sData s2)
        {
            sData temp = s1;
            s1 = s2;
            s2 = temp;

            PrintStruct(s1, s2);
        }

        static public void PrintStruct(sData s1, sData s2) 
        {

            Console.WriteLine($"s1: {s1._num1}  s1: {s1._num2}");
            Console.WriteLine($"s2: {s2._num1}  s2: {s2._num2}");

        }
        static void Main(string[] args)
        {
            int num1 = 100;
            int num2 = 500;

            SwapValue(num1,num2);          //여기서 num1, num2값이 바뀌지 않는다
            Print(num1, num2);

            SwapRef(ref num1, ref num2);   //ref int로 받고 출력하니 바뀌었다.  참조에 의한 전달해야한다.
            Print(num1, num2);            //레퍼런스를 함수의 파라미터값으로 써주고 호출할때도 ref써야함.

            {
                sData s1 = new sData(0, 0);
                sData s2 = new sData(500, 500);

                PrintStruct(s1, s2);          //바뀌기전
                SwapStructValue(ref s1,ref s2); //스왑
                PrintStruct(s1, s2);          //바뀐후
            }
        }
    }
}
