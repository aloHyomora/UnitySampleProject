using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    internal class Army
    {
        protected uint Level;
        protected uint Exp;
        protected uint Hp;
        protected bool IsAlive;

        protected uint Movement_Speed;
        protected uint Attack_Power;
        protected string Name;

        protected float PositionX;
        protected float PositionY;

        protected uint DamageExp;

        public Army()
        {
            Level = 1;
            Exp = 0;
            IsAlive = true;
            
            PositionX = 0;
            PositionY = 0;

            Console.Write("객체 생성");
        }
        public void Move(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Attack(uint gainExp/*, uint hp*/)     //다른 상대의 hp를 의미함. 
        {
            /*if (hp <= 0)*/

            Exp += gainExp;
        }
        public void PrintStat()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Hp: {Hp}, Exp: {Exp}");
            Console.WriteLine($"PositionX: {PositionX}, PositionY: {PositionY}");

        }
        public uint GetAttack_Power()
        {
            return Attack_Power;
        }

        public uint GetMovement_Speed()
        {
            return Movement_Speed;
        }
        public uint Damage(uint damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                IsAlive = false;
            }

            return DamageExp;  //공격하는 대상에게 리턴하는 경험치  내가 죽으면 가져감?
        }
    }
}
