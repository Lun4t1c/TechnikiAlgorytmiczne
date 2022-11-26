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
                        Console.WriteLine();
                        PerformSorts();
                        Console.WriteLine();
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

            Console.Write("> ");
            return Console.ReadLine();
        }

        private static void PerformSorts()
        {
            for (int i = 10; i < 100; i++)
            {
                Console.WriteLine();

                Utilities.GenerateNewInputFile(i);
                string sortedString = Utilities.ReadStringFromInputFile();

                for (int j = 0; j < i; j++)
                    Console.Write('-');
                Console.WriteLine();

                Console.WriteLine("Sorting:");
                Console.WriteLine(sortedString);
                Console.WriteLine();
                
                Console.WriteLine("Counting...");
                Console.WriteLine(Sorts.Counting(sortedString.ToCharArray()));

                Console.WriteLine();

                Console.WriteLine("Radix...");
                Console.WriteLine(Sorts.Radix(sortedString.ToCharArray()));                

                Console.WriteLine();
            }
        }
    }
}