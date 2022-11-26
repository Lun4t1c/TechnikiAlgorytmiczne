using System;
using System.IO;

namespace SortingProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                switch (PrintPrompt())
                {
                    case "1":
                        Console.Write("Number of characters: ");
                        int charsNumber = int.Parse(Console.ReadLine());
                        Utilities.GenerateNewInputFile(charsNumber);
                        Console.WriteLine("New input generated:");
                        Console.WriteLine(Utilities.ReadStringFromInputFile());
                        break;

                    case "2":
                        break;

                    case "0":
                        return;

                    default:
                        break;
                }

            }            
        }

        private static string PrintPrompt()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("1. Generate new input file.");
            Console.WriteLine("2. Perform sorts.");
            Console.WriteLine("0. Exit.");

            return Console.ReadLine();
        }
    }
}