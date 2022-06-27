using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_MinMax_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5명의 키를 읽은 후 평균과 최소, 최대값을 구하여 출력한다.

            float max = float.MinValue;
            float min = float.MaxValue;
            float sum = default;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("키를 입력하세요(단위 : cm) : ");
                float height = float.Parse(Console.ReadLine());
                if (height > max)
                    max = height;
                if (height < min)
                    min = height;
                sum += height;                
            }

            Console.WriteLine(" 평균 키 : {0}cm, 최대 : {1}cm, 최소 : {2}cm", sum / 5, max, min);
        }
    }
}
