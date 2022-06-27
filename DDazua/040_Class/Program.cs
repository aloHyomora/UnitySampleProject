using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _040_Class  // class는 사용자 자료형의 또 다른 레퍼런스 자료형일 뿐
{
    public class AA     //public : 참조  , ~~구조체랑 비슷한 형태
    {
        //멤버 변수(state) (상태)
        public int num;
        public float fNum;
        public string text;

        //멤버 함수(행동)
        public AA()    //struct와 달리 멤버변수 초기화X
        {

        }
        
        public void SetNum(int _num)
        {
            num=_num;
        }

        public void Print()
        {
            Console.WriteLine($"num: {num} fNum: {fNum} text: {text}");
        }
    }

    public class Car
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AA aa;  //레퍼런스 이름만 선언 (객체가 안만들어짐)
            aa = new AA(); // Instance (객체가 되었다.) //메모리공간 할당 
            aa.num = 100;
            aa.SetNum(100);
            aa.Print();

            AA bb = new AA();   //레퍼런스 선언동시에 메모리할당
            bb.num = 100;
            bb.fNum = 103.22f;
            bb.text = "BBB";
            bb.Print();

            Car Sedan = new Car();                               //클래스 선언방법
            Car coupe, Weagon; //int num1, num2 처럼 선언가능~
            Car SUV = new Car(), VEN = new Car();
            Car Hatchback;
            Hatchback = new Car();
        }
    }
}
