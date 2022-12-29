using System;
using System.IO;

namespace BSTTreeProject
{
    public static class Program
    {
        public const int ELEMENTS_MIN = 100;
        public const int ELEMENTS_MAX = 10000;
        public const int ELEMENTS_STEP = 100;

        public static string[] FirstSet = { "OSA", "KOS", "AS", "LAS" };

        public static void Main(string[] args)
        {
            BSTTree tree = new BSTTree();
            Random random = new Random();

            int amount = 100;
            for (int i = 0; i < amount; i++)
                tree.Add(FirstSet[random.Next(FirstSet.Length)]);
            

            tree.PrintOut();
        }
    }
}