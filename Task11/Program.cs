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
            char [] alf=CreateAlf();
            char [] str = CreateString(alf);
            string s = Encode(str, alf);
            Console.Write("Закодированная строка "); Console.WriteLine(s);
            s = Decode(alf, s.ToCharArray());
            Console.Write("Раскодированная строка "); Console.WriteLine(s);
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
                Console.Write("Первый символ (как правило 1) "); arr[0] = ReadAnswer();
                Console.Write("Второй символ (как правило 0) "); arr[1] = ReadAnswer();
                if (arr[0] != arr[1]) ok = true;
                else
                {
                    Console.WriteLine("Элементы алфавита должны отличаться, введите еще раз.");
                    ok = false;
                }
            } while (!ok);
            return arr;
        }

        static bool ReadChar(char [] alf, char s)
        {
            if (s == alf[0] || s == alf[1]) return true;
            else return false;
        }

        static char[] CreateString(char [] alf)
        {

            char[] arr = new char[0];
            bool ok = true;
            do
            {
                Console.Write("Введите строку:"); string res = Console.ReadLine(); 
                arr = res.ToCharArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!ReadChar(alf, arr[i])) // If all the symbols in the string fit the alphabet
                    {
                        ok = false;
                        break;
                    }
                    else ok = true;
                }                   
                if (!ok) Console.WriteLine("Строка имела неверный формат");
            } while (!ok);
           
            return arr;
        }

        static string  Encode(char[] str, char[] alf)
        {
            string result = "";
            result=result.Insert(0, str[0].ToString());
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i-1])
                {
                    result += alf[0];
                }
                else
                {
                    result += alf[1];
                }
            }
                 
            return result;
        }

        static string Decode(char[] alf, char[] str)
        {
            string result = "";
            result += str[0];
            string temp =result;
            string another;
            if (temp == Convert.ToString(alf[0])) another = Convert.ToString(alf[1]); // Chose the symbol from the alphabet to be the next
            else another = alf[0].ToString();
            for (int i = 1; i < str.Length; i++)
                if (str[i] == alf[1])
                {
                    string t = temp;
                    temp = another;
                    another = t;
                    result = result.Insert(i, temp);
                }
                else
                {
                    result += temp;
                }
            return result;
        }
    }
}
