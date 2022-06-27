using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _041_Constructor
{
    internal class Program
    {
        class AA
        {
            //멤버변수
            private int num1;    //private 접근 지정자  클래스 안에서만 멤버 변수를 부를 수 있다.
            private string text;

            public AA()   //디폴트 생성자, 파라미터가 없는 형태의 생성자를 말함
            {
                num1 = 0;
                text = "";
            }

            public AA(int _num1)
            {
                num1 = _num1;
            }

            public AA(int _num1, string _text)
            {
                num1 = _num1;
                text = _text;
            }

            public void Print()
            {
                Console.WriteLine("num1: " + num1);
                Console.WriteLine("text: " + text);

            }
        }


        //생성자는 분석하기 쉽고 유연하게 코딩할 수 있도록 도움을 준다.
        class BB
        {
            private int num1;
            private int num2;
                             
            //디폴트 생성자 없어유 없어도 없는것처럼 작동
            public BB() { } //디폴트 생성자 그래도 만들어주자~

            public BB(int n1, int n2) //멤버 함수를 통해서 값을 받아서 멤버 변수를 초기화
            {
                num1 = n1;
                num2 = n2;
            }

            public void SetNum(int n1,int n2) 
            {
                num1 = n1;
                num2 = n2;
            }

            public void Print()
            {
                Console.WriteLine($"num1: " + num1);
                Console.WriteLine($"num2: " + num2);
            }
        }

        class CopyTest
        {
            private int num;
            private string text;

            public CopyTest() { }  //디폴트 생성자
            public CopyTest(int n, string t)
            {
                num = n;
                text = t;
            }

            //복사 생성자 
            public CopyTest(CopyTest copyInstance)  //생성자 함수가 자기 자신의 객체를 직접 받아서 값을 초기화하려는것
            {
                num=copyInstance.num;    //초기화
                text = copyInstance.text;
            }

            public void SetData(int n,string t)
            {
                num = n;
                text = t;
            }
            public void Print()
            {
                Console.WriteLine($"num: " + num);
                Console.WriteLine($"text: " + text);
                
            }
        }

        static void Main(string[] args)
        {
            AA aa = new AA(10);
            aa.Print();

            AA bb = new AA(20, "texT");
            bb.Print();
            // AA.num1   부를 수 없다. private 접근지정자를 사용했기 때문에

            BB cc = new BB(30,40);            
            cc.Print();            //num1: 0 ,  num2: 0   Class BB에 디폴트 생성자를 만들지 않아도 디폴트생성자있는것처럼 작동
           
            cc.SetNum(100, 100); //멤버함수로 값을 받기 위해 SetNum이 필요함

            CopyTest copyTest = new CopyTest(100,"Hello"); //하나라도 다른 생성자를 만들었다면 디폴트생성자는 필요하다.
            CopyTest cloneTest = new CopyTest(copyTest);  //동일하게 넣어라

            copyTest.Print();
            cloneTest.Print();
            Console.WriteLine();

            cloneTest.SetData(5000, "World");  //깊은 복사가 되지 않는다? cloneTest만 바뀜
            copyTest.Print();
            cloneTest.Print();
            Console.WriteLine();

            copyTest.SetData(99999, "hhhhh");  //copyTest만 바뀌고 cloneTest는 바뀌지 않음
            copyTest.Print();
            cloneTest.Print();
            Console.WriteLine();

            /*copyTest = null;  ---->>   CopyTest cloneTest = new CopyTest(copyTest); 이런 식으로 연동되어있기때문
            cloneTest.Print();*/


            Console.WriteLine("\n===== cloneTest2 ====\n");

            CopyTest cloneTest2 = copyTest;  //새로운 객체로 복사를 할 경우 동일하게 넣은 값들이 다 바뀌어버린다.
            copyTest.Print();
            cloneTest2.Print();
            Console.WriteLine();

            cloneTest2.SetData(9000, "WORLD");
            copyTest.Print();
            cloneTest2.Print();
            Console.WriteLine();

            copyTest = null;    //copyTest가 null값을 가져도 cloneTest2는 살아있다.
            cloneTest2.Print();
        }
    }
}
