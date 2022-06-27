using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    internal class Giant:Army
    {        

        public Giant(bool isPrintStat = true):base()
        {            
            Hp = 1000;            

            Movement_Speed = 2;
            Attack_Power = 50;

            Name = "거인";

            DamageExp=Level * 4;
            if (isPrintStat)PrintStat();
        }

        public Giant(float positionX, float positionY)
        {
            Level = 1;
            Exp = 0;
            Hp = 1000;
            IsAlive = true;

            Movement_Speed = 2;
            Attack_Power = 50;

            Name = "거인";            

            PositionX = positionX;
            PositionY = positionY;

            PrintStat();
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);
            Console.WriteLine($"자이언트 이동 => 위치 X: {PositionX} 위치 Y: {PositionY}");

        }
        public override void Attack(Army damageArmy)
        {
            base.Attack(damageArmy);

            string damageName = damageArmy.GetName();
            uint gainExp = damageArmy.GetDamageExp();

            Console.WriteLine($"{Name}이 {damageName}을 몸통박치기 공격!");
            Console.WriteLine($"{Name}이 {gainExp}획득!");
        }
    }
}
