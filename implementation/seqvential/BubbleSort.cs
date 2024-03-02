using MEPSortingAlgorithms.utils.iface;
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

        public double RunBubbleSort(string inputFilePath)
        {
            ArgumentNullException.ThrowIfNull(inputFilePath);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int[] arr = sortHelper.ReadDataFromFile(inputFilePath);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (arr is null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return -1;
            }

            Console.WriteLine("Array before sorting:");
            sortHelper.PrintArray(arr);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();

            Console.WriteLine("\nArray after sorting:");
            sortHelper.PrintArray(arr);


            double executionTime = stopwatch.Elapsed.TotalSeconds * 10;
            Console.WriteLine($"\nTime taken to sort: {executionTime} seconds");
            return executionTime; // Return the sorted array.
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