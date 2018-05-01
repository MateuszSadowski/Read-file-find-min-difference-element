using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecruitmentTask
{
    class Program
    {
        static List<float> parsedNumbers = new List<float>();
        static TextReader inputStream = Console.In;
        static String textInput = null;
        static void Main(string[] args)
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("This program requires that input is redirected from a file.");
                return;
            }

            ReadFileFromStandardInput();
            ParseNumbers();
            foreach (var item in parsedNumbers)
            {
                System.Console.WriteLine(item);
            }
        }

        private static void ReadFileFromStandardInput()
        {
            try
            {
                textInput = inputStream.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static void ParseNumbers()
        {
            String[] numbers = textInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in numbers)
            {
                ParseNumber(number);
            }
        }

        private static void ParseNumber(String number)
        {
            float parsedNumber;
            bool result = float.TryParse(number, out parsedNumber);
            if (result)
            {
                parsedNumbers.Add(parsedNumber);
            }
            else
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                    number == null ? "<null>" : number);
            }
        }

        // private static int FindClosestElement()
        // {
        //     //int[] toSum = parsedNumbers.ToArray();
        //     float sum = parsedNumbers.Aggregate((a,b) => a + b);
        //     float toCheckValue = 0.25 * sum;
        // }
    }
}