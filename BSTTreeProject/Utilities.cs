using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTTreeProject
{
    internal static class Utilities
    {
        public static readonly string[] IGNORED_STRINGS = { " ", "\n", "\r\n", "\r", "\t", "-", "—", ".", ",", "?", "!", "(", ")", ";", ":", "«", "»" };

        public const string EXAMPLE_TEXT_FILE_PATH = "pan-tadeusz.txt";

        public const string FIRST_REPORT_FILE_PATH = "OperationsSet1.txt";
        public const string SECOND_REPORT_FILE_PATH = "OperationsSet2.txt";
        public const string THIRD_REPORT_FILE_PATH = "OperationsSet3.txt";

        public static void TouchOperationFiles()
        {
            File.Create(FIRST_REPORT_FILE_PATH);
            File.Create(SECOND_REPORT_FILE_PATH);
            File.Create(THIRD_REPORT_FILE_PATH);
        }

        public static string[] GetSecondSet()
        {
            List<string> result = new List<string>();

            foreach (string s in _getExampleText())
                if (s.Length < 4)
                    result.Add(s);

            return result.ToArray();
        }

        public static string[] GetThirdSet()
        {
            return _getExampleText();
        }

        private static string[] _getExampleText()
        {
            string AllText = File.ReadAllText(EXAMPLE_TEXT_FILE_PATH);
            AllText = AllText.Replace("\r\n", " ");
            string[] AllTextArray = AllText.Split(' ');

            return _fixStringArray(AllTextArray);
        }

        private static string[] _fixStringArray(string[] words)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (IGNORED_STRINGS.Contains(words[i]) || words[i] == "") continue;

                string tempString = words[i];
                foreach (string s in IGNORED_STRINGS)
                    tempString = tempString.Replace(s, "");

                result.Add(tempString.ToLower());
            }

            return result.ToArray();
        }
    }
}
