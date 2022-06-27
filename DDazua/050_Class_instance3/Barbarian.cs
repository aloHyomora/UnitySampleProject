using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    internal class Barbarian :Army
    {
        

        public Barbarian(bool isPrintStat=true):base() // (bool isPrintStat=true) , :this(false)하는 이유 PrintStat() 두번출력방지
        {            
            Hp = 500;           

            Movement_Speed = 10; 
            Attack_Power = 10;

            Name = "바바리안";

            DamageExp = Level * 2;

            if (isPrintStat) PrintStat();
        }

        public Barbarian(float positionX, float positionY):this(false)
        {
           /* Level = 1;       // 생성자를 호출하는 this로 프로그램이 훨씬 간단해짐
            Exp = 0;
            Hp = 500;
            IsAlive = true;

            Movement_Speed = 10;
            Attack_Power = 10;

            Name = "바바리안";*/

            PositionX = positionX;
            PositionY = positionY;

            PrintStat();
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);

            Console.WriteLine($"바바리안 이동 => 위치 X: {PositionX} 위치 Y: {PositionY}");
        }
        public override void Attack(Army damageArmy)  //내가 공격을 하고 공격을 받는 애의 이름과 exp를 우리한테 리턴해주겠다.
        {
            base.Attack(damageArmy);           

            string damageName = damageArmy.GetName();
            uint gainExp = damageArmy.GetDamageExp();

            Console.WriteLine($"{Name}이 {damageName}을 주먹 공격!");
            Console.WriteLine($"{Name}이 {gainExp}획득!");

        }
    }
}
