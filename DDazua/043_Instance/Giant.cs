using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _043_Instance
{
    internal class Giant
    {
        private uint Level;  // 0부터 시작~이니까 uint형
        private uint Exp;
        private uint Hp;
        private bool IsAlive;

        private uint Movement_Speed;
        private uint Attack_Power;
        private string Name;

        private float PositionX;
        private float PositionY;

        public Giant()
        {
            Level = 1;
            Exp = 0;
            Hp = 1000;
            IsAlive = true;

            Movement_Speed = 2;
            Attack_Power = 50;

            Name = "거인";

            PositionX = 0;
            PositionY = 0;

            PrintStat();
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

        public uint Damage(uint damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                IsAlive = false;
            }

            return Level*2;  //공격하는 대상에게 리턴하는 경험치  내가 죽으면 가져감?
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
    }
}
