using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString;
            string secondString;
            string stringResult;
            string stringToCheck;

            Console.WriteLine("Please type a string: ");
            firstString = Console.ReadLine();
            Console.WriteLine("Please type another string: ");
            secondString = Console.ReadLine();

            //1.concatenate the 2 strings
            stringResult = string.Concat(firstString, secondString);
            Console.WriteLine("The string result is : {0}",stringResult);

            //2.capital letters for all text
            Console.WriteLine("The first string in capital letters is : {0}", firstString.ToUpper());
            Console.WriteLine("The second string in capital letters : {0}", secondString.ToUpper());

            //3.replace 'a' letters with 'b' letters (from the results from concatenate)
            Console.WriteLine("The first string in capital letters is : {0}", stringResult.Replace('a','b'));
            
            //prereq for 4
            Console.WriteLine("Please type a string to search for: ");
            stringToCheck = Console.ReadLine();

            //4.
            if (stringResult.Contains(stringToCheck)==true)
            {
                Console.WriteLine("your result contains the text typed");
            } else
            {
                Console.WriteLine("your result doesn't contain the text typed");
            }

            //5.calculate the string result length
            Console.WriteLine("The resulted string contains {0} characters",stringResult.Length);

            //prereq for 6
            Console.WriteLine("Please type a string to search for: ");
            stringToCheck = Console.ReadLine();

            //6.returns the index of the text previously entered
            if ((stringResult.IndexOf(stringToCheck) + 1) > 0)
            {
                Console.WriteLine("Your string was found starting from position : {0}", stringResult.IndexOf(stringToCheck) + 1);
            }
            else
            {
                Console.WriteLine("Your string wasn't found");
            }

            //7.take the last character of a string
            Console.WriteLine("The last character of your string is : {0}", stringResult.Last());
        }
    }
}
