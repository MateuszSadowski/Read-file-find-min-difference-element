using System;

namespace RecruitmentTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("This program requires that input is redirected from a file.");
                return;
            }

            var inputStream = Console.In;

            try
            {
                String line = inputStream.ReadToEnd();
                Console.WriteLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}