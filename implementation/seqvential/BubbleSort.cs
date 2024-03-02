using MEPSortingAlgorithms.utils;
using System.Diagnostics;

namespace MEPSortingAlgorithms.algorith.seqvential
{
    public class BubbleSort
    {
        public BubbleSort()
        {
        }

        public static void RunBubbleSort(string inputFilePath)
        {
            ISortHelper sortHelper = new SortHelper();

            if (string.IsNullOrEmpty(inputFilePath))
            {
                throw new ArgumentException($"'{nameof(inputFilePath)}' cannot be null or empty.", nameof(inputFilePath));
            }

            // Citirea setului de date din fișier
            int[] arr = sortHelper.ReadDataFromFile(inputFilePath);

            if (arr == null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return;
            }

            // Afișarea setului de date inițial
            Console.WriteLine("Array before sorting:");
            sortHelper.PrintArray(arr);

            // Sortarea setului de date folosind Bubble Sort și măsurarea timpului de execuție
            Stopwatch stopwatch = new();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Afișarea setului de date sortat și timpul de execuție
            Console.WriteLine("\nArray after sorting:");
            sortHelper.PrintArray(arr);
            Console.WriteLine("\nTime taken to sort: " + elapsedTime.TotalSeconds * 10 + " seconds");
        }

        private static void BubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    }
                }
            }
        }
    }
}