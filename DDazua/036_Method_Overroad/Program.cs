using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _036_Method_Overroad
{
    // 1. 함수의 이름은 동일
    // 2. 파라미터 수가 다름
    // 3. 파라미터의 데이터형이 다름
    // 4. 리턴 데이터가 다른 경우에는 오버로딩 불가   static int aaa(??)  !=  static void aaa(??) 이럴때
    internal class Program
    {
        // 1. 함수의 이름이 동일하다.
        static void SumInt(int a,int b)
        {
            Console.WriteLine($"SumInt: {a + b }");
        }

        static void SumFloat(float a, float b)
        {
            Console.WriteLine($"SumFloat: {a + b}");
        }
       

        static void Sum(int a,int b)                   //파라미터수가 다르거나 자료형이 다를때 overroad성립
        {
            Console.WriteLine($"Sum: {a + b}");
        }
        static void Sum(float a, float b)
        {
            Console.WriteLine($"Sum: {a + b}");
        }

        struct Splayer
        {
            int level;
            int exp;
            string name;

            public Splayer(int _lv,int _exp) //생성자1 오버로드도가능하다.
            {
                level = _lv;
                exp = _exp;
                name = "";
            }

            public Splayer(int _lv, int _exp,string _name = "aaa") //생성자2 오버로드가능 ""디폴트값말고 초기화하면 큰 문제없이 나옴
            {
                level = _lv;
                exp = _exp;
                name = _name;
            }

            public void Print()
            {
                Console.WriteLine($"level : {level}  exp : {exp}  name : {name}");
            }

            public int Print(string text) //리턴데이터가 다른데 파라미터가 다르다? 정상적으로 작동
            {
                Console.WriteLine(text);
                Console.WriteLine($"level : {level}  exp : {exp}  name : {name}");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            SumInt(10, 20);
            SumFloat(10.0f, 10.01f);

            Sum(10, 30);
            Sum(20.0f, 2.2f);

            Splayer player = new Splayer(10, 100);
            player.Print();

            Splayer player1 = new Splayer(10, 100,"AAA");
            player1.Print();
            player1.Print("Result");

            
        }
    }
}
