using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _047_Class_Inheritance //base클래스는 접근지정자를 활용하여 안정적이고 방어적인 프로그래밍가능~
{
    class BaseAA
    {

        private string PrivateText;   //private 접근지정자는 제외~ 못 가져가
        protected string protectedText; //반드시 상속구조에서만 필요한 접근 지정자, 상속받은 애들만 가져다 쓸수있다.
        public int num;
        protected int testnum;

        public BaseAA()  //디폴트생성자를 만들어 줘야 한다.
        {
            PrivateText = "BaseAA privateText";
            Console.WriteLine("BaseAA");
        }
        //class AA, BB가 class BaseAA를 부르고 있다. 베이스 클래스안에 생성자 함수가  없어서 문제가 된다.

        
        public BaseAA(int num):this() //나 자신의 다른 함수를 부르겠다. 
        {
            Console.WriteLine("BaseAA(int num)");
            this.num = num;
        }

        public void Print()
        {
            Console.WriteLine("num: " + num);
        }
        public void PrintprotectedText()
        {
            Console.WriteLine("protectedText: " + protectedText);
        }
        private void PrintPrivateText() //private 부를 수 없다.
        {
            Console.WriteLine("PrivateText: " + PrivateText);
        }
        protected void Printprotected() //private 부를 수 없다.
        {
            Console.WriteLine("PrivateText: " + PrivateText);
        }

        public void SetTestNum(int n)  //SetTestNum을 통해서만 값을 넣을 수 있도로 방어되어있다.
        {
            if (n >= 100)
            {
                Console.WriteLine("반드시 입력값은 100보다 작은 값");
                return;
            }
            testnum = n;
        }

        public int GetTestNum()
        {
            return testnum;
        }
    }

    class AA : BaseAA //  : 상속받을이름  ---> BaseAA로부터 AA가 상속을 받는형태
    {

        public AA()   //여기서 :base() 로 부르지 않아도 디폴트로 알아서 base가 불러진다.
        {            
        }
        public AA(int num) : base(num)
        {
            protectedText = "protectedText-AA";
        }    
        public void printprotectedTextAA()
        {
            base.PrintprotectedText();

            base.PrintprotectedText();
        }
    }

    class BB : BaseAA
    {
        /*private string PrivateText;
        public string publicText;
        int num;*/
       
        public BB(int num):base(num)   //BB에 있는 num은 AA와 다르다.
        {
            protectedText = "protectedText-BB";

        }

        public void printprotectedTextAA()
        {
            base.PrintprotectedText();
            base.PrintprotectedText();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //클래스 상속 기초
            {
                AA aa = new AA(100);  //특정한 함수를 부르지 않으면 base가 불려진다.
                aa.printprotectedTextAA();  //printprotectedTextAA호출 -> 상속받은 PrintprotectedText, PrintprotectedText실행
                BB bb= new BB(3000); 
                bb.printprotectedTextAA();
            } 
            {
                AA aa= new AA();
                aa.Print();
                aa.PrintprotectedText();  //베이스 클래스에 public되어있는 멤버변수나 멤버함수는 객체를 만들고 접근가능하다.

               
                aa.SetTestNum(1333);
                Console.WriteLine(aa.GetTestNum());  //0출력 
                aa.SetTestNum(15);
                Console.WriteLine(aa.GetTestNum());

                BB bb = new BB(20);
                bb.SetTestNum(1311);
                Console.WriteLine(bb.GetTestNum());
            }
        }
    }
}
