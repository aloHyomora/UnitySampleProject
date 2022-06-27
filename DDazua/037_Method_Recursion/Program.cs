using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_Method_Recursion    //재귀함수 ~ 대부분 반복문으로 표현가능 프로그램에 따라 적절히 사용
{
    internal class Program
    {
        //종료 조건에 주의!
        static uint AddLoop(uint num)   //자기자신을 반복적으로 호출하는 형태
        {
            return (num > 0 ? num + AddLoop(num - 1) : 0); //3항연산자num이 0보다 큰 경우 num +AddLoop(num - 1) 하고 그렇지 않을 경우 0을 넘겨라
            /*if (num == 0)                     
            {
                return 0; //num ==0 일때 종료           // " Ctrl+Shift+/ " 주석처리
            }
            else
            {
                return num + AddLoop(num - 1);  //5입력  -->  5+4+3+2+1+0   //메모리에 중첩되는 형태
            }*/
        }

        static uint AddLoopFor(uint num)  
        {
            uint total = 0;

            for (uint i = num ; i >0; i--)  //uint형이기 때문에 i>=0이 안됨 소수점~
            {
                total += i;
            }
            return total;
        }

        static void SortSelect(int[] numbers, int startIndex)
        {
            if (startIndex >= numbers.Length) //배열의 크기보다 시작이 작아야함 startIndex가 크면 종료
                return;

            var minIndex = startIndex; //처음 받은 수를 일단 제일 작은 수라고 정하고
            for (int i = startIndex+1; i < numbers.Length; i++) //1,2,3,4 4번반복
            {
                if (numbers[minIndex] > numbers[i])   //numbers[0]>numbers[1]
                {
                    minIndex = i;    // numbers[i]가 더 작은 경우 minIndex값을 i로 바꿔준다.
                }
            }
            int temp=numbers[startIndex];
            numbers[startIndex]=numbers[minIndex];
            numbers[minIndex]=temp;

            SortSelect(numbers, startIndex + 1); //재귀함수  --> 얘가 반복돌려서 최소값 배열위치 바꿔준다
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("AddLoop: " + AddLoop(5));
            Console.WriteLine("AddLoopFor: " + AddLoopFor(5));

            //Console.WriteLine("AddLoop: " + AddLoop(1000000)); //스택이 overflow돼서 예외처리함 
                                                                 //숫자가 큰 경우 재귀함수사용이 불가능
            Console.WriteLine("AddLoopFor: " + AddLoopFor(1000000)); //정상적 출력, 큰 경우 for반복사용해야함

            int[] array = { 16, 22, 13, 4, 100 ,32};
            PrintArray(array);

            Console.WriteLine();
            SortSelect(array, 3);  //배열 3번부터 정렬
            PrintArray(array);
            
            
            Console.WriteLine();
            SortSelect(array,0);  //0번부터 정렬
            PrintArray(array);


        }
    }
}
