using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // C#에서 배열은 참조형이므로 다음과 같이 new 키워드를 사용해 생성한다.
            // 배열 선언과 출력
            int[] a = {1,2,3};
            Console.Write("a[]: ");
            foreach (var value in a)
                Console.Write($"{value,3}");

            int[] b = new int[] {4,5,6};
            Console.Write("\nb[]: ");
            foreach (var value in b)
                Console.Write($"{value,3}");

            int[] c =new int[3] {7,8,9};
            Console.Write("\nc[]: ");
            for (int i = 0; i < c.Length; i++)
                Console.Write($"{c[i],3}");

            int[] d = new int[3] { 10, 11, 12 };
            Console.Write("\nd[]: ");
            for (int i = 0; i < d.Length; i++)
                Console.Write($"{d[i],3}");


            // 다차원 배열 : 2차원
            Console.WriteLine();
            Console.WriteLine("2차원 배열 : arrA[2,3]");
            int[,] arrA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write($"{arrA[i, j]} ");
                Console.WriteLine();
            }
            
            Console.WriteLine("2차원 가변 배열 : arrB[2][3]");
            int[][] arrB = new int[2][];
            arrB[0] = new int[] { 1, 2 };
            arrB[1] = new int[] { 3, 4, 5, 6 };
            for (int i = 0; i < arrB[0].Length; i++)
            {
                for (int j = 0; j < arrB[i].Length; j++)
                    Console.Write($"{arrB[i][j]} ");
                Console.WriteLine();
            }

            // 문자열 배열에 저장하고 정렬
            string[] name = { "Mouse", "Cow", "Tiger", "Rabbit", "Lion" };
            PrintArray("Before Sort: ",name);

            Array.Reverse(name);
            PrintArray("After Reverse: ", name);

            Array.Sort(name);
            PrintArray("After Sort: ", name);


            void PrintArray(string s, string[] arr)
            {
                Console.WriteLine($"{s}: ");
                foreach (var name1 in arr)
                    Console.Write("{0} ",name1);
                Console.WriteLine();
            }

            // Random 클래스 -> 참조형이므로 new 키워드로 객체 생성
            Random random = new Random();
            Console.Write("{0, -16}","Random Bytes");
            Byte[] B =new byte[5];
            random.NextBytes(B);

            foreach (var item in B)
                Console.Write("{0,12}",item);
            Console.WriteLine();


            Console.Write("{0,-16}", "Random Double");
            Double[] D = new double[5];
            for (int i = 0; i < D.Length; i++)
            {
                D[i] = random.NextDouble();
            }
            foreach (var value in D)                                            
                Console.Write("{0,12:F8}", value);            
            Console.WriteLine();

            int z = random.Next(1, 100);
            Console.WriteLine(z);


            // 배열에서 최소, 최대, 평균 계산
            int[] v = new int[20];
            for (int i = 0; i < v.Length; i++)            
                v[i] = random.Next(100);
            PArray(v);

            int max = v[0];
            for (int i = 1; i < v.Length; i++)   
                if(v[i] > max) max = v[i];

            int min = v[0];
            for (int i = 0; i < v.Length; i++)
                if(v[i]<min) min = v[i];

            int sum = 0;
            for (int i = 0; i < v.Length; i++)
            {
                sum += v[i];
            }

            Console.WriteLine($"v배열에서 최대값은 {max}이고 최소값은 {min}이고 합계는 {sum}이고 평균은{(float)sum / v.Length}");

            void PArray(int[] s)
            {
                for (int i = 0; i < s.Length; i++)
                    Console.Write("{0,5}{1}", s[i], (i % 10 == 9) ? "\n" : "");
            }
        }
    }
}
