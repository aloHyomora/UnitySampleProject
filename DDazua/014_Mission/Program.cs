using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Mission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "A, b, C, D, e, F, G, H, I, j, K";
            string[] splitdata = data.Split(','); //splitdata에 data문자열을 배열로 받아 저장
            string capitalLetter = "";
            string smallLetter = "";

            Console.WriteLine("data: " +data);

            for (int i = 0; i < splitdata.Length; i++)
            {
                char asckey = char.Parse(splitdata[i].Trim());

                if(asckey >='A' && asckey <= 'Z')
                {
                    capitalLetter += asckey;
                    capitalLetter += String.Format("  index: {0}\n", i);
                }
                else
                {
                    smallLetter += asckey;
                    smallLetter += String.Format("  index: {0}\n", i);
                }
            }
            Console.WriteLine(capitalLetter);
            Console.WriteLine(smallLetter); 
        }
    }
}
