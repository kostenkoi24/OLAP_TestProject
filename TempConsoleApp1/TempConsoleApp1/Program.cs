using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TempConsoleApp1
{

   /* public class RegexEvaluator
    {
        public static string EvaluateRegex(string pattern, string evalString)
        {
            Regex rg = new Regex(pattern);
            string retval = "";
            MatchCollection matches = rg.Matches(evalString);
            for (int count = 0; count < matches.Count; count++)
            {
                retval += matches[count].Value;
            }
            return retval;
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string pattern = "<[^>]*>";
            string evalString = "<p>Доброго дня!</p><p>Встановіть ціну на товар від постачальника на уцінку, н/н 71149838-Чайник DELONGHI KBZ 2001 BK ,не можемо роздрукувати цінник, оскільки ціна підтягується 0, 000700007799462-№ АПБ.</p>";

            Regex rg = new Regex(pattern);
            
            string retval = Regex.Replace(evalString, "<[^>\"=]*>", String.Empty);

                  
            Console.WriteLine(pattern);
            Console.WriteLine(evalString);
            Console.WriteLine(retval);
            Console.ReadKey();

        }
    }
}
