using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Code_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call FizzBuzz for number 0 to 20
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }

            // Call LetterCounter with the given strings
            LetterCounter('i', "I love biscuits and gravy. It's the best breakfast ever.");
            LetterCounter('n', "Never gonna give you up. Never gonna let you down.");
            LetterCounter('s', "Sally sells seashells down by the seashore. She's from Sussex.");

            // Keep the console open to read the results
            Console.ReadKey();
        }
        /// <summary>
        /// Classical FizzBuzz with if's
        /// </summary>
        /// <param name="number">number to check</param>
        static void FizzBuzz(int number)
        {
            // if the number is divisable by 5 and 3 print "FizzBuzz"
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 5 == 0)
            {
                // is divisable by 5
                Console.WriteLine("Fizz");
            }
            else if (number % 3 == 0)
            {
                // is divisible by 3
                Console.WriteLine("Buzz");
            }
            else
            {
                // The number is not divisible by 3 or 5 or both together, print the number
                Console.WriteLine(number);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="letter">letter to check for</param>
        /// <param name="inString">string to analyze</param>
        static void LetterCounter(char letter, string inString)
        {
            // Declare counters
            int lowerCaseCounter = 0;
            int upperCaseCounter=0;

            // Loop over every character in the string
            foreach (char stringLetter in inString)
            {
                if (letter.ToString().ToLower() == stringLetter.ToString())
                {
                    // matches the lowercase version
                    lowerCaseCounter++;
                }
                else if (letter.ToString().ToUpper() == stringLetter.ToString())
                {
                    // matches the UPPERCASE version
                    upperCaseCounter++;
                }
            }

            // Print output to console
            Console.WriteLine("Input: " + inString);
            Console.WriteLine("Number of lowercase " + letter + "'s found: " + lowerCaseCounter);
            Console.WriteLine("Number of UPPERCASE " + letter + "'s found: " + upperCaseCounter);
            Console.WriteLine("Total Number of " + letter + "'s found: " + (lowerCaseCounter + upperCaseCounter));
        }
    }
}
