using System;
using Instance;

namespace _048_Class_Instance2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //유닛 테스트
            {
                Barbarian[] barbarians = new Barbarian[10];       //이 상태는 객체생성한것 아님  

                // Barbarian b1, b2, b3; //객체 이름만 만들어졌지 사용하기 위한 Instance는 안만들어졌다.

                barbarians[0] = new Barbarian();
                barbarians[1] = new Barbarian(10, 10);

                uint gainExp = barbarians[1].Damage(barbarians[0].GetAttack_Power());
                barbarians[0].Attack(gainExp);

                Console.WriteLine("\nResult\n");

                foreach (var item in barbarians)
                {
                    if (item != null)
                    {
                        item.PrintStat();
                    }
                }

                Console.WriteLine("");
                /* barbarians[0].PrintStat();    //이렇게 출력해도 됨 foreach문으로 작성한 것
                 barbarians[1].PrintStat();*/

                Giant[] giants = new Giant[10];
                giants[0] = new Giant();
                giants[1] = new Giant(20, 20);

                barbarians[0].Attack(giants[0].Damage(barbarians[0].GetAttack_Power()));
                barbarians[0].Attack(giants[0].Damage(barbarians[0].GetAttack_Power()));
                barbarians[0].Attack(giants[0].Damage(barbarians[0].GetAttack_Power()));

                Console.WriteLine("\nResult\n");
                foreach (var item in giants)
                {
                    if (item != null)
                    {
                        item.PrintStat();
                    }
                }
                foreach (var item in barbarians)
                {
                    if (item != null)
                    {
                        item.PrintStat();
                    }
                }

                Healer h1 = new Healer(20,20);
                h1.Attack(giants[0].Damage(h1.GetAttack_Power()));
                h1.PrintStat();
                giants[0].PrintStat();
            }
        }
    }
}
