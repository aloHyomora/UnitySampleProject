using System;


namespace _999_BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[] v = new int[30];
            for (int i = 0; i < v.Length; i++)
                v[i] = random.Next(1, 1000);
            PrintArray("정렬 전",v);

            Array.Sort(v);
            PrintArray("정렬 후", v);

            Console.WriteLine("=> 검색할 숫자를 입력하세요: ");
            int key = int.Parse(Console.ReadLine());
            int count = 0; // 비교횟수

            for (int i = 0; i < v.Length-1; i++)
            {
                count++;
                if (key==v[i])
                {
                    Console.WriteLine("v[{0}] = {1}", i, key);
                    Console.WriteLine($"선형탐색의 비교횟수는 {count}회입니다.");
                    break;
                }
            }

            count = 0;
            int low = 0;
            int high = v.Length-1;
            while (low <= high)
            {
                count++;
                int mid = (low+high)/2;
                if (v[mid] == key)
                {
                    Console.WriteLine($"v[{mid}] = {key}");
                    Console.WriteLine("이진탐색의 비교횟수는 {0}회입니다.", count);
                    break;
                }
                else if (key > v[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
        }

        private static void PrintArray(string s, int[] v)
        {
            Console.WriteLine(s);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("{0,5}{1}", v[i], (i % 10 == 9 ? "\n" : ""));
            }
            
        }
    }
}
