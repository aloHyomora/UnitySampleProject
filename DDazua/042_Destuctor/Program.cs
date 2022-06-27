using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _042_Destuctor
{
    internal class Program
    {
        class AA
        {
            public AA() //생성자
            {
                Console.WriteLine("AA 생성자 호출");
            }

            ~AA()    //소멸자   ~클래스이름()   파라미터 없음
            {
                Console.WriteLine("AA 소멸자 호출");
            }
        }

        //using, 상속, interface
        class DiposeTest : IDisposable
        {
            public DiposeTest()
            {
                Console.WriteLine("DiposeTest 생성자 호출");
            }

            public void Dispose()    //IDisposable 인터페이스 구현이 안돼있기 때문에 재정의해야함.
            {
                Console.WriteLine("Dispose 호출");
            }
        }

        
     
        static void Main(string[] args)
        {
            {
                AA aa = new AA();
            }

            {
                IDisposable dt = new DiposeTest();  //객체 생성 
            }

            Console.WriteLine("프로그램 종료");
        }
    }
}
