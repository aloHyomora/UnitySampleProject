using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문자열 기초
            {
                char[] str = "abcd".ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write($"{str[i]}");
                }
            }

            //레퍼런스 체크하기
            {
                Console.Write("\n String 기초");

                string str1 = "abcdefg"; //""리터럴
                string str2 = str1;

                if(object.ReferenceEquals(str1, str2))  //레퍼런스가 동일한가?
                {
                    Console.WriteLine("동일한 레퍼런스");  //str2가 바뀌면 str1도 바뀜
                }                                          //주소로 하는 느낌             

                int num1 = 100;
                int num2 = num1;

                if (object.ReferenceEquals(num1, num2))    //값에 의한 데이터가 아님
                {
                    Console.WriteLine("동일한 레퍼런스");
                }
                else
                {
                    Console.WriteLine("동일한 레퍼런스가 아님");
                }

                
            }
            {
                {
                    Console.Write("\n String 기초\n");

                    string str1 = "Hello World";
                    Console.WriteLine($"{str1}");

                    //초기화 방법
                    char[] ch1 = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };
                    string str2 = new string(ch1);

                    //==
                    if (str1 == str2)
                    {
                        Console.WriteLine("str1 == str2");
                    }
                    //Equals
                    if (str1.Equals(str2))
                    {
                        Console.WriteLine("str1 == str2");
                    }

                    Console.WriteLine($"str1.Length: {str1.Length}"); //000.Length 문자열 길
                    Console.WriteLine($"str1.GetType(): {str1.GetType()}");
                    Console.WriteLine($"+= : {str2 += "HHHH"}");

                    var str3 = string.Format("{0} {1} {2} {0}", "Hi", "Hello", "Gold");
                    Console.WriteLine($"str3: {str3}");

                    string str4 = "c:/user/document/hello.cs";
                    //파일이름 hello.cs가 필요함(substring)
                    int lastindex = str4.LastIndexOf("/")+1;  //뒤에서 부터 '/'를찾음 찾으면 그 문자열 번호를 알려줌  
                    Console.WriteLine($"Substring: {str4.Substring(lastindex, (str4.Length - lastindex))}");
                    Console.WriteLine($"lastIndex: {lastindex} str4.Length = lastIndex: {str4.Length - lastindex}");

                    string str5 = "      abcdefghijk ";
                    Console.WriteLine($"str5: {str5}");
                    if (str5.Contains("d")||str5.Contains("i"))                        
                    {
                        str5 = str5.Replace("d", " ");
                        str5 = str5.Replace("i", " ");
                    }
                    Console.WriteLine($"Replace str5: {str5}");
                    Console.WriteLine($"ToUpper str5: {str5.ToUpper()}");

                    string trimstr5=str5.Trim(); //앞뒤 공백 제거만 중간에 있는것은 유지된다.
                    Console.WriteLine($"Trim str5: {trimstr5}");

                    string whiteSpaceStr = trimstr5.Replace(" ", "");
                    Console.WriteLine($"whiteSpaceStr: {whiteSpaceStr}");

                    string str6="AA,BB,CC,DD";
                    string[] arrayStrs = str6.Split(','); //Split을 , 로 하면 배열로 뽑을수있다
                    Console.Write("arrayStrs");
                    for (int i = 0; i < arrayStrs.Length; i++)
                    {
                        
                        Console.Write($"   {arrayStrs[i]}  ");
                    }
                }

            }



        }
    }
}
