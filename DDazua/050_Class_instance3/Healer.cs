using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    internal class Healer:Army
    {
       public Healer(bool isPrintStat=true ):base()//상속자함수
        {
            Hp = 400;

            Movement_Speed = 10;
            Attack_Power = 3;

            Name = "힐러";

            DamageExp = Level * 3;

            if (isPrintStat) PrintStat();
        }
        public Healer(float positionX, float positionY) : this(false)
        {
            PositionX = positionX;
            PositionY = positionY;

            PrintStat();
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);

            Console.WriteLine($"힐러 이동 => 위치 X: {PositionX} 위치 Y: {PositionY}");
        }
        public override void Attack(Army damageArmy)
        {
            base.Attack(damageArmy);

            string damageName = damageArmy.GetName();
            uint gainExp = damageArmy.GetDamageExp();

            Console.WriteLine($"{Name}이 {damageName}을 마법으로 공격!");
            Console.WriteLine($"{Name}이 {gainExp}획득!");
        }
    }
}
