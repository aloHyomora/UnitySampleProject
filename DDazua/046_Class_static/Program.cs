using System;
using static System.Console;
using static _046_Class_static.AA;

namespace _046_Class_static
{
    class AA
    {
        //1. 객체를 생성하지 않아도 접근 가능하다.
        public int num;
        public static int sNum;
        public static int instanceNum;

        public AA()
        {
            ++instanceNum; // 객체가 몇개 만들어 졌는지 알 수 있다.

            Console.WriteLine("instanceNum: " + instanceNum);
        }

        public void AddStaticNum()
        {
            ++sNum;
        }
        
        public void Print()
        {
            Console.WriteLine($"num: {num}");
            Console.WriteLine($"sNum: {sNum}");
        }

        //static 함수(정적 함수)는 반드시 정적 변수만 사용 가능
        public static void StaticPrint()
        {
            //Console.WriteLine($"num: {num}"); //에러 public int num; 으로 정의된 변수
            Console.WriteLine($"StaticPrint sNum: {sNum}");
            Console.WriteLine($"StaticPrint instanceNum: {instanceNum}");
        }
    }

    class SingletonTest
    {
        private int num;
        //1. 생성자를 private
        private SingletonTest() { num = 0; }

        //2. 객체생성이 유일하다(static)...
        private static SingletonTest instance = new SingletonTest();

        //3. 외부에서 접근이 가능한 함수를 제공
        public static SingletonTest GetInstance()
        {
            if (instance == null)
            {
                instance=new SingletonTest();
            }

            return instance;
        }

        public void AddNum()
        {
            ++num;
        }
        
        public void Print()
        {
            Console.WriteLine($"num: {num}");
        }
    }

    //중첩된 정적 메소드 
    namespace NameAA
    {
        namespace NameAA
        {
            public class AAA
            {
                public static void Print()
                {
                    Console.WriteLine("NameAA_AAA_Print"); ;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //static 기초
            {
                { 
                AA.sNum = 1000;

                AA aa1 = new AA();
                AA aa2 = new AA();

                aa1.num = 100;
                aa2.num = 200;

                aa1.AddStaticNum();
                aa1.Print(); //1001

                aa2.AddStaticNum();
                aa1.Print(); //1002
                aa2.Print(); //1002

                AA.StaticPrint();   //정적 함수는 객체를 만들지 않아도 사용가능

                AA[] arrayAA = new AA[10]; //객체를 보관할 수 있는 변수를 10개 만듬
                arrayAA[0] = new AA();
                arrayAA[1] = new AA();
                }
                //싱글톤 패턴 처리 => 매니저 클래스..
                {
                    SingletonTest st1= SingletonTest.GetInstance(); //두 개의 객체를 만들었다. 하지만 동일한 값이다.
                    SingletonTest st2= SingletonTest.GetInstance();

                    Console.WriteLine("객체가 동일한가? "+st1.Equals(st2));

                    st1.AddNum();
                    st2.AddNum();

                    st1.Print(); //둘다 2출력 같은 객체이기 때문에 
                    st2.Print();
                }

                {
                    SingletonTest st3=SingletonTest.GetInstance(); //다 동일, singleton으로 만들어져 있기 때문에 밑에 여러개의 객체들이 안의 GetInstance를 가져오면
                    st3.Print();                                  //객체가 유일하기 때문에 다 동일한 값이다.
                }

                {
                    NameAA.NameAA.AAA.Print();
                }
            }
        }
    }
}
