using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999_Practice
{
    internal class BMI_Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("키를 입력하세요(cm): ");
            float height = float.Parse(Console.ReadLine());
            height /= 100;

            Console.WriteLine("몸무게를 입력하세요(kg): ");
            float weight = float.Parse(Console.ReadLine());

            float BMI = weight / (height * height);
            string howfat= null;
            if (BMI < 20)
                howfat = "저체중";
            else if (BMI >= 20 && BMI < 25)
                howfat = "정상체중";
            else if (25 <= BMI && BMI < 30)
                howfat = "경도비만";
            else if (BMI >= 30 && BMI < 40)
                howfat = "비만";
            else howfat = "고도비만";

            Console.WriteLine($"키는 {height}m, 몸무게는 {weight}kg, BMI값은 {BMI}이고 \"{howfat}\"이다. ");
            Console.WriteLine($"키는 {0}m이고 몸무게는 {1}kg, BMI값은 {2}이고 \"{3}\"이다.", height, weight, BMI, howfat);
        }
    }
}
