using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _035_Mehod_Default
{
    internal class Program
    {
         //디폴트 매개변수 
        static void PrintDefault(int num1,int num2=0, string text= "")    //맨 뒤의 매개변수부터 앞으로 가면서 채워져야 한다.
        {                                                                //int num1, int num2=0, string text  이런식으로 되면 오류남
            Console.WriteLine($"num1: {num1}");
            Console.WriteLine($"num2: {num2}");
            Console.WriteLine($"text: {text}");

        }

        static void Print(string[] arrayStr)         //string str1,string str2, string str3 -->>  string[] arrayStr
        {
            if (arrayStr == null) return;  //반환값이 없다. 프로그램이 끝남 break와 비슷
            for (int i = 0; i < arrayStr.Length; i++)
            {
                Console.WriteLine($"{i}: {arrayStr[i]}");
            }
        }
        
        //params 키워드 ---> 배열로 편하게 이용할때 사용하면 편함
        static void PrintParam(params string[] arrayStr)         //string str1,string str2, string str3 -->>  string[] arrayStr
        {                                     
            if (arrayStr == null) return;  //반환값이 없다. 프로그램이 끝남 break와 비슷
            for (int i = 0; i < arrayStr.Length; i++)
            {
                Console.WriteLine($"{i}: {arrayStr[i]}");
            }
        }


        static void Main(string[] args)
        {
            //디폴트 매개변수
            {
                PrintDefault(10);      // 10, 0, ""가 정상적으로 출력
                PrintDefault(10, 20);
                PrintDefault(10, 20, "AAA");
                //PrintDefault(10, "AAA); 오류난다 뒤에서 부터 순서대로 채워야 함.
            }

            //명명된 인수 
            {
                PrintDefault(num1: 10);
                //PrintDefault(num2: 100); num1값이 없기 때문에 오류
                PrintDefault(10, text: "BBBB"); //num2 = 0 으로 값이 존재하기 때문에 가능한 형태
                PrintDefault(num1: 10, 10, text: "CCC");
                PrintDefault(text: "DDD", num1: 10);  //순서가 뒤바뀌어도 값있으면 에러안남.
            }

            //params 
            {
                Print(new string[] { "AA", "BB" });
                Print(null);

                //Print(); ---> 에러: 배열은 불가
                //Print("AA", "BB"); ---> 에러: 배열은 불가        간단하게 사용하기 위해 만들어진게  params 
                PrintParam("aa", "bb");  //params는 배열과 함께 사용가능
                
            }
        }
    }
}
