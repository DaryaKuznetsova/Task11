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
            char [] arr=CreateAlf();
            char [] str = CreateString(arr);
           
            //s = CreateLine(s);
            //Console.WriteLine(s);
            //s = Decode(s);
            //Console.WriteLine(s);
        }

        static char ReadAnswer()
        {
            char a = ' ';
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToChar(Console.ReadLine());
                    if (a > 0)
                        ok = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите один символ.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }


        static char[] CreateAlf()
        {
            char[] arr = new char[2];
            bool ok = false;
            do
            {
                Console.WriteLine("Введите кодирующий алфавит (2 символа):");
                Console.Write("Первый символ "); arr[0] = ReadAnswer();
                Console.Write("Второй символ "); arr[0] = ReadAnswer();
                if (arr[0] != arr[1]) ok = true;
                else
                {
                    Console.WriteLine("Элементы алфавита должны отличаться, введите еще раз.");
                }
            } while (!ok);
            return arr;
        }

        static char[] CreateString(char [] alf)
        {
            Console.Write("Введите строку:"); string res = Console.ReadLine();
            char []arr = res.ToCharArray();
            bool ok = false;
            do
            {
                ok = true;
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] != alf[0] && arr[i] != alf[1]) ok = false;
            } while (!ok);
            return arr;
        }

        static string  Encode(string str, char[] alf)
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
