using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_Mehod
{
    internal class Program
    {
        //파라미터x(입력값 매개변수가 없다), 리턴x  함수는 4개의 형태가 존재
        static void PrintHello()  //void -> 리턴 없다  PrintHello( 공백 ) 파라미터x
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("11");
            Console.WriteLine("2");
        }


        //파라미터o, 리턴x
        static void PrintValue(int x)   //매개변수로 전달받아야함. 
        {
            Console.WriteLine($"PrintValue: {x}"); 
        }
        static void Printsum(int x,int y)
        {
            Console.WriteLine($" x + y = {x + y}");
        }


        //파라미터x, 리턴o
        static int GetMaxInt()
        {
            return int.MaxValue;
        }


        //파라미터o, 리턴o
        static int ReturnSum(int x, int y)
        {
            int total = x + y;
            return total;  //ReturnSum함수호출끝나면 total값을 메인으로 리턴
        }


        struct Sstuent
        {
            int  _id;
            string  _name;          //public 안써서 접근할 수 없으니 만들어준다

            public Sstuent(int id, string name)  //생성자 
            {  
                _id = id;
                _name = name;     
            } 
            public int GetID()
            {
                return _id; 
            }
            public string GetName()
            {
                return _name;
            }
            public void SetID(int id)
            {
                _id = id;
            }
            public void SetName(string name)
            {
                _name = name;
            }
            public void PrintData()
            {
                Console.WriteLine($"_id: {_id}  _name: {_name}");
            }
        }
        static void Main(string[] args)  //static있을때 사용하려면 위에 static사용해야함
        {
            PrintHello();  //파라미터가 없기 때문에 입력값없이 사용가능 
                          //main함수에 줄줄이 함수를 만드는 것보다 편함, 유지보수가 좋다.          

            PrintValue(1);
            PrintValue(23);

            Printsum(3, 7);
            Printsum(323, 6759);

            int maxValue=GetMaxInt();
            Console.WriteLine(($"maxValue : {maxValue}"));

            int sumValue = ReturnSum(10, 100);
            Console.WriteLine($"sumValue : {sumValue}");

            Sstuent[] students=new Sstuent[3];

            foreach (var item in students)
            {
                item.PrintData();
            }
            //아직 stuendts 구조체 배열에 입력된 값이 없다.
            students[0].SetID(0);   
            students[0].SetName("aa");
            
            students[1]=new Sstuent(1,"bb");
            students[2] = new Sstuent(2, "cc");

            foreach (var item in students) //입력하고 출력
            {
                item.PrintData();
            }
        }
    }
}
