using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _049_Class_virtual  //_048_Class_Instance2에서 barbarian, giants, healer 각 객체로 배열선언한것을
{                             //가상함수를 통해서 간소화할 수 있다.

    //virtual 기초 (가상함수 기초)   --오버라이드의 개념이 강함
     class Super  //override를 통해 재정의한다. --
    {
        public Super() { }
        public virtual void Print()
        {
            Console.WriteLine("Super: Print()");
        }
        public virtual void HelloWorld()
        {
            Console.WriteLine("Super: HelloWorld()");

        }
        public virtual int GetNum()
        {
            Console.WriteLine("Super: GetNum()");
            return 0;
        }
        public void TestMethod()  //virtual가 아니 그냥함수, 재정의된 함수가 아니기 때문에 바로 자기함수호출
        {
            Console.WriteLine("Super: TestMethod()");
        }
        //public static virtual void Method() { }  //static은 virtual와 불가
        //private virtual void Test() { }          //private 접근 지정자 사용불가
                
    }
     class AA : Super
        {
            public AA() : base()
            {

            }
            public override void Print()
            {
                // base.Print();
                Console.WriteLine("AA: Print()");
            }
            public override void HelloWorld()
            {
                //base.HelloWorld();
                Console.WriteLine("AA: HelloWorld()");
            }
            public override int GetNum()
            {
                //return base.GetNum();
                Console.WriteLine("AA: GetNum()");
                return 1000;
            }

        }
    class BB : Super
    {
        public BB() : base()
        {

        }
    }
    class CC: Super
    {
        public CC() : base()
        {            
        }
        public override void Print()
        {
            //base.Print();
            Console.WriteLine("CC: Print()");

        }
    }
     internal class Program
       {
          static void Main(string[] args)
          {
            Super aa1 = new Super();
            aa1.Print();

            Super aa2 = new AA();
            aa2.Print();
            aa2.HelloWorld();
            int num = aa2.GetNum();
            Console.WriteLine("num: " + num);  //AA클래스가 Super클래스를 상속받음
            aa2.TestMethod();   //TestMethod는 부모 클래스에서 상속받은 경우로 부모 클래스의 함수 호출이 가능하다.

            //업케스팅 객체를 만드는 경우는 다형성을 지원하게 된다.(단, virtual함수에 의해서)
            //
            {
                AA[] instanceAA = { new AA(), new AA(), new AA(), new AA() };
                BB[] instanceBB = { new BB(), new BB(), new BB(), new BB() };
                CC[] instanceCC = { new CC(), new CC(), new CC(), new CC() };

                foreach (var item in instanceBB) //  --> 클래스 BB는 재정의 하지않아서 부모클래스인 Super을 출력
                {
                    item.Print();
                }
                foreach (var item in instanceAA) //  --> 그래서 하나로 묶어서 처리할 수 없다.
                {
                    item.Print();
                }
                foreach (var item in instanceCC) //  --> 알아서 자기가 재정의되어있는 자기만의 프린트를 만들수있다는 장점
                {
                    item.Print();
                }

                Console.WriteLine();
                Super[] instances = { new AA(), new AA(), new AA(), new AA(), new CC(), new CC(), new CC(), new CC() };
                foreach (var item in instances)
                {
                    item.Print();
                }
                //결론: 하나의 데이터로 처리가 가능하다. 반복문을 줄일 수 있다.
            }
        }
    }
}


