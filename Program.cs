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

        static float minDifference = float.MaxValue;
        static float middleValue = 0;
        static float minDifferenceNumber = 0;
        static void Main(string[] args)
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("This program requires that input is redirected from a file.");
                return;
            }

            ReadFileFromStandardInput();
            ParseNumbers();
            FindNumberWithMinDifference();

            System.Console.WriteLine("Result: {0}", minDifferenceNumber);
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

        private static void FindNumberWithMinDifference()
        {
            float sum = parsedNumbers.Aggregate((a,b) => a + b);
            middleValue = (float) 0.25 * sum;
            TryAllNumbers();
        }

        private static void TryAllNumbers()
        {
            foreach (var number in parsedNumbers)
            {
                TryNumber(number);
            }
        }

        private static void TryNumber(float number)
        {
            float difference = Math.Abs(middleValue - number);
            if(difference < minDifference)
            {
                minDifference = difference;
                minDifferenceNumber = number;
            }
        }
    }
}