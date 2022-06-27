using System;


namespace _025_break_continue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //break 기초
            {
                Console.WriteLine("\n break  기초");

                int num = 0;

                for (int i = 0; i < 10; i++)
                {
                    if (i == 6) break;

                    Console.WriteLine($"i: {i}");

                }
                //for(;;) ->아무조건없이 반복 무한루프
                while (true) //무한루프 반드시 끝날수있게
                {
                    if (++num > 10) break;
                    Console.WriteLine($"num: {num}");
                }

                switch (num)
                {
                    case 10:
                    case 11:
                        Console.WriteLine($"switch num: {num}");
                        break;
                    default:
                        break;
                }

                {
                    Console.WriteLine("\n 대소문자 출력");

                    int numAa = 65;           //A          
                    int length = (90 - numAa);//Z
                    int smalla = 97;
                    int smalllength = smalla + length;

                    for (int i = 0; i < length; i++)
                    {
                        Console.Write($"{(char)(numAa + i)}   ");
                        for (int j = smalla; j < smalllength; j++)
                        {
                            if ((numAa + i) == j - 32)  //32 : (97-65)
                            {
                                Console.Write($"{(char)j}   ");
                                break;
                            }

                        }
                        Console.WriteLine();
                    }

                    //continue 기초
                    {
                        Console.WriteLine("\ncontinue 기초");
                    }
                    int numm = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 5 || i == 7)
                            continue;
                        Console.WriteLine($"i: {i}");
                    }
                }
            }
            {
                Console.WriteLine("\n 대소문자 출력");

                int numAa = 65;           //A          
                int length = (90 - numAa);//Z
                int smalla = 97;
                int smalllength = smalla + length;

                for (int i = 0; i < length; i++)
                {
                    Console.Write($"{(char)(numAa + i)}   ");
                    for (int j = smalla; j < smalllength; j++)
                    {
                        if ((numAa + i) == j - 32)  //32 : (97-65)
                        {
                            Console.Write($"{(char)(numAa + i)}");
                            continue;
                        }
                        Console.Write($"{(char)j}  ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
