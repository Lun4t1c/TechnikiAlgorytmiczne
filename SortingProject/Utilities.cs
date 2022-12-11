using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingProject
{
    internal static class Utilities
    {
        public static string INPUT_FILE_PATH = "InputFile.txt";
        public readonly static char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        public static void GenerateNewInputFile(int wordLength)
        {
            Random random = new Random();
            string outputString = "";

            for (int i = 0; i < wordLength; i++)
                outputString += Alphabet[random.Next(Alphabet.Length)];

            File.WriteAllText(INPUT_FILE_PATH, outputString);
        }

        public static string ReadStringFromInputFile()
        {
            string output = "";

            try
            {
                output = File.ReadAllText(INPUT_FILE_PATH);
            }
            catch (Exception exc) 
            {
                Console.WriteLine(exc.Message);
            }

            return output;
        }
    }
}
