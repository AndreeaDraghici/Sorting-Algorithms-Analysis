using MEPSortingAlgorithms.utils;
using System.Diagnostics;

namespace MEPSortingAlgorithms.algorith.seqvential
{
    public class BubbleSort
    {
        private readonly ISortHelper sortHelper;
        public BubbleSort(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public void RunBubbleSort(string inputFilePath)
        {
            ArgumentNullException.ThrowIfNull(inputFilePath);

            int[] arr = sortHelper.ReadDataFromFile(inputFilePath);

            if (arr is null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return;
            }

            Console.WriteLine("Array before sorting:");
            sortHelper.PrintArray(arr);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();

            Console.WriteLine("\nArray after sorting:");
            sortHelper.PrintArray(arr);

            Console.WriteLine($"\nTime taken to sort: {stopwatch.Elapsed.TotalSeconds * 10} seconds");
        }

        private void BubbleSortAlgorithm(int[] arr)
        {
            int size = arr.Length;
            // Loop for each pass through the array.
            for (int i = 0; i < size - 1; i++)
            {
                // Loop to compare adjacent elements.
                for (int idx = 0; idx < size - i - 1; idx++)
                {
                    // If the current element is greater than the next, swap them.
                    if (arr[idx] > arr[idx + 1])
                    {
                        // Swapping elements using tuple deconstruction for readability.
                        (arr[idx + 1], arr[idx]) = (arr[idx], arr[idx + 1]);
                    }
                }
            }
        }
    }
}