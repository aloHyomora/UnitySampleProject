using System;
using NameAA;
using NameAAA;
using AA = NameAA.AA; //별명 사용..
using AAA = NameAAA.AA;
using BBB = NameBBB.subBBB.BBB;

//namespace 기초(class, interface, struct, enum, delegate)이 정도의 키워드로 만들어짐.
namespace NameAA
{
    //int num; 오류
    public class AA  //public 안써도 에러 안난다. 기본적으로 접근지정자가 public으로 되어있다.
    {
        public AA()
        {
            Console.WriteLine("NAmeAA AA Instance");
        }
    }

    struct MyStruct
    {

    }

    enum MyEnum
    {

    }

    delegate void Print();
}

namespace NameAAA
{
    public class AA  //같은 이름의 클래스를 가질 수 있다. 다른 namespace에 존재하기 때문
    {
        public AA()
        {
            Console.WriteLine("NameAAA AA Instance");
        }
    }
}

namespace NameBB //namesspace 중첩
{
    namespace subBB
    {
        class BB {
            public BB()
            {
                Console.WriteLine("NameBB_subBB_BB Instance");
            }
        }
    }
}

namespace NameBBB.subBBB
{
    class BBB
    {
        public BBB()
        {
            Console.WriteLine("NameBBB_subBBB_BBB Instance");
        }
    }
}
namespace _045_Class_namespace
{
   

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //namespace 기초
            {
                AA aa1 = new AA(); //using NameAA 해줬기 때문에 
                AAA aa2 = new AAA();
                //NameAAA.AA aa3 = new NameAAA.AA(); 처럼 . 을 이용해도 좋다
            }

            System.Console.WriteLine("");  //using System을 해줬기 때문에 System. 안써도 됨

            //namespace 중첩
            {
                NameBB.subBB.BB bb = new NameBB.subBB.BB();   //using NameBB.subBB; 사용해서 앞에 줄일 수도 있음.

                NameBBB.subBBB.BBB bbb = new NameBBB.subBBB.BBB(); //using NameBBB.subBBB; 사용해서 앞에 줄일 수도 있음.
            }
        }
    }
}
