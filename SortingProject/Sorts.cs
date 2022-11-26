using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingProject
{
    internal static class Sorts
    {
        readonly static char[] Alphabet = Utilities.Alphabet;
        readonly static int MAX_COUNT = Alphabet.Length;

        public static char[] Counting(char[] input)
        {
            char[] output = new char[input.Length];
            int[] count = new int[MAX_COUNT];

            for (int i = 0; i < MAX_COUNT; i++)
                count[i] = 0;

            for (int i = 0; i < input.Length; i++)
                count[input[i] - 97]++;

            for (int i = 1; i <= MAX_COUNT - 1; i++)
                count[i] += count[i - 1];

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output[count[input[i]-97] - 1] = input[i];
                count[input[i]-97]--;
            }

            return output;
        }

        public static char[] Counting(char[] input, int exp)
        {
            char[] output = new char[input.Length];
            int[] count = new int[MAX_COUNT];

            for (int i = 0; i < MAX_COUNT; i++)
                count[i] = 0;

            for (int i = 0; i < input.Length; i++)
                count[(input[i] / exp) % 10]++;

            for (int i = 1; i < MAX_COUNT; i++)
                count[i] += count[i - 1];

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output[count[(input[i] / exp) % 10] - 1] = input[i];
                count[(input[i] / exp) % 10]--;
            }

            return output;
        }

        public static char[] Radix(char[] input)
        {
            int m = GetMax(input);
            char[] output = new char[input.Length];
            Array.Copy(input, output, input.Length);

            for (int exp = 1; m / exp > 0; exp *= 10)
                output = Counting(output, exp);

            return output;
        }

        private static char GetMax(char[] input)
        {
            char temp = input[0];

            for (int i = 1; i < input.Length; i++)
                if (temp < input[i])
                    temp = input[i];

            return temp;
        }
    }
}
