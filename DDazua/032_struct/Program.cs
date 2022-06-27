using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_struct  //구조체 사용자가 원하는 자료형을 만들겠다.
{
    //private
    //public

     class Program //struct 구조체는 main함수내에서 선언 불가 class나 namespace에 위치
    {              //외부에서 작업하고 main함수로 가져오겠다
       public struct sData     //namespace안에서 는 public만 사용가능, private는 외부에서 접근불가
        {
            public int _num1;  //public 공개되어있는 속성
            public int _num2;    

            
            public sData(int num1,int num2) //num1,2를 받아서 초기화하겠다
            {
                _num1 = num1;   
                _num2 = num2;   
            }           
        }

        struct Mypoint  //public을 안쓴다면 기본적으로 가지고 있는 값은 private이다.
        {
            public int x;
            public int y;

            public Mypoint(int xData,int yData)
            {
                x = xData;  
                y = yData;
            }

            
        }

        struct sinformation
        {
            public int id;
            public string names;
            public string sex;

            public sinformation(int _id, string _names, string _sex)  //생성자 
            {
                id = _id;
                names = _names;
                sex = _sex;
            }
        }

        static void Main(string[] args)
        {
            {
                int num;
                sData data = new sData(0, 10); //0과 10이 매개변수로 넘기면 _num1,2에 저장됨 
                Console.WriteLine($"_num1: {data._num1}");
                Console.WriteLine($"_num2: {data._num2}");
            }

            {
                Mypoint point = new Mypoint(10, 10); //new로 형성하지 않아도 된다. 포인트에 직접 접근하면 x보이지 않는다
                Console.WriteLine($"point: {point.x}");
                Console.WriteLine($"point: {point.y}");


                Mypoint point2;            //캡슐화되어있다. 접근할수있게 만들어준다.
                point2.x = 100;
                point2.y = 200;
                Console.WriteLine($"point2: {point2.x}");
                Console.WriteLine($"point2: {point2.y}");
            }

            {
                //id, 이름, 성별
                sinformation[] arrayinfor = new sinformation[3];
                arrayinfor[0].id = 0;
                arrayinfor[0].names = "aa";
                arrayinfor[0].sex = "female";

                arrayinfor[1].id = 0;
                arrayinfor[1].names = "bb";
                arrayinfor[1].sex = "male";

                arrayinfor[2].id = 0;
                arrayinfor[2].names = "cc";
                arrayinfor[2].sex = "female";

                foreach (var s in arrayinfor)
                {
                    Console.WriteLine($"id: {s.id}");
                    Console.WriteLine($"names:{s.names}");
                    Console.WriteLine($"sex: {s.sex}");
                }

                Console.Write("찾으려는 이름이 무엇입니까?");
                string name=Console.ReadLine();
                sinformation finda=new sinformation(); //초기화필수 그렇지 않으면 아래진행시 오류

                foreach (var s in arrayinfor)
                {
                    if (s.names.Equals(name))
                    {
                        finda = s;
                        break;
                    }
                    
                }

                if (string.IsNullOrEmpty(finda.names))
                {
                    Console.WriteLine("없습니다.");

                }
                else
                {
                    Console.WriteLine($"id: {finda.id}");
                    Console.WriteLine($"names:{finda.names}");
                    Console.WriteLine($"sex: {finda.sex}");
                }
                //구조체에서 생성자를 만들어줘야함 오류안나려면
                sinformation[] testinfor = {new sinformation(0,"aa","aaa"),new sinformation(1,"bb","bbb")};
            }
        }
    }
}
