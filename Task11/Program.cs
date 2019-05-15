using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "10110";
            s = CreateLine(s);
            Console.WriteLine(s);
            s = Decode(s);
            Console.WriteLine(s);
        }

        static string  CreateLine(string str)
        {
            string result = "";
            Array arr = str.ToCharArray();
            result=result.Insert(0, Convert.ToString(arr.GetValue(0)));
            for (int i = 1; i < arr.Length; i++)
                if ((char)arr.GetValue(i) == (char)arr.GetValue(i - 1))
                {
                    result = result.Insert(i, "1");
                    Console.WriteLine(result);
                }
                else
                {
                    result = result.Insert(i, "0");
                    Console.WriteLine(result);
                }

     
            return result;
        }

        static string Decode(string str)
        {
            string[] alf = new string[] { "0", "1" };
            string result = "";
            Array arr = str.ToCharArray();
            result = result.Insert(0, Convert.ToString(arr.GetValue(0)));
            string temp =result;
            string another;
            if (temp == alf[0]) another = alf[1];
            else another = alf[0];
            for (int i = 1; i < arr.Length; i++)
                if ((char)arr.GetValue(i) == '0')
                {
                    string t = temp;
                    temp = another;
                    another = t;

                    result = result.Insert(i, temp);
                    Console.WriteLine(result);
                }
                else
                {
                    result = result.Insert(i, temp);
                    Console.WriteLine(result);
                }
            return result;
        }
    }
}
