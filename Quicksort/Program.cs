namespace Quicksort
{
    class Program
    {        
        public static void Main(string[] args)
        {
            int[] arr = { 1, 6, 2, 7, 4, 76, 34, 23 };

            Console.WriteLine(Partition(arr, 0, arr.Length - 1));

        }

        public static void quicksort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int i = Partition(arr, l, r);
                quicksort(arr, l, i - 1);
                quicksort(arr, i + 1, r);
            }
        }

        public static int Partition(int[] arr, int l, int r)
        {
            int partitionIndex = ChoosePivot(l, r);
            int partitionValue = arr[partitionIndex];
            SwitchValues(arr, partitionIndex, r);

            int currentIndex = 1;
            for (int i = l; i < r - 1; i++)
            {
                if (arr[i] < partitionValue)
                {
                    SwitchValues(arr, i, currentIndex);
                    currentIndex++;
                }
            }

            SwitchValues(arr, currentIndex, r);
            return currentIndex;
        }

        public static int ChoosePivot(int l, int r)
        {
            return (l + (r - l)) / 2;
        }

        public static void SwitchValues(int[] arr, int i1, int i2)
        {
            if (i1 != i2)
            {
                int temp = arr[i1];
                arr[i1] = arr[i2];
                arr[i2] = temp;
            }
        }
    }
}