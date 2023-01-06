using System;
using System.IO;

namespace BSTTreeProject
{
    public static class Program
    {
        public const int ELEMENTS_MIN = 100;
        public const int ELEMENTS_MAX = 10000;
        public const int ELEMENTS_STEP = 100;
        public const int OPERATION_TEST_CASES = 100;

        public static string[] FirstSet = { "OSA", "KOS", "AS", "LAS" };
        public static string[] SecondSet = Utilities.GetSecondSet();
        public static string[] ThirdSet = Utilities.GetThirdSet();

        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = customCulture;

            TestSet(FirstSet, Utilities.FIRST_REPORT_FILE_PATH);
            TestSet(SecondSet, Utilities.SECOND_REPORT_FILE_PATH);
            TestSet(ThirdSet, Utilities.THIRD_REPORT_FILE_PATH);
        }

        public static void TestSet(string[] set, string operationsFilePath)
        {
            Console.WriteLine("Testing set...");
            string fileContent = "";

            for (int amount = ELEMENTS_MIN;
                     amount <= ELEMENTS_MAX; 
                     amount += ELEMENTS_STEP
                )
            {
                Console.WriteLine($"Amount: {amount}");

                BSTTree tree = new BSTTree();
                Random random = new Random();
                float averageOperationsInserting = 0;
                float averageOperationsFinding = 0;
                float averageOperationsDeleting = 0;

                tree.FlushNumberOfOperations();                

                for (int i = 0; i < amount; i++)
                {
                    tree.Add(set[random.Next(set.Length)]);
                    averageOperationsInserting += tree.FlushNumberOfOperations();
                }
                averageOperationsInserting /= amount;
                Console.WriteLine($"averageOperationsInserting: {averageOperationsInserting}");
                

                // FINDING
                for (int i = 0; i < OPERATION_TEST_CASES; i++)
                {
                    tree.Find(set[random.Next(set.Length)]);
                    averageOperationsFinding += tree.FlushNumberOfOperations();
                }
                averageOperationsFinding /= OPERATION_TEST_CASES;
                Console.WriteLine($"averageOperationsFinding: {averageOperationsFinding}");

                // DELETING
                for (int i = 0; i < OPERATION_TEST_CASES; i++)
                {
                    tree.Remove(set[random.Next(set.Length)]);
                    averageOperationsDeleting += tree.FlushNumberOfOperations();
                }
                averageOperationsDeleting /= OPERATION_TEST_CASES;
                Console.WriteLine($"averageOperationsDeleting: {averageOperationsDeleting}");

                // ADD FILE CONTENT
                fileContent += $"{amount};{averageOperationsInserting};{averageOperationsFinding};{averageOperationsDeleting};{tree.GetHeight()};\n";

                Console.WriteLine();
            }
            Console.WriteLine();
            File.WriteAllText(operationsFilePath, fileContent);
        }
    }
}