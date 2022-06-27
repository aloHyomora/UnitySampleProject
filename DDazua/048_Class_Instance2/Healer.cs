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

    }
}
