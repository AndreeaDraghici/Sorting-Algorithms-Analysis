using MEPSortingAlgorithms.utils.iface;
using System.Diagnostics;

namespace MEPSortingAlgorithms.algorith.seqvential
{
    public class BubbleSortSecvential
    {
        private readonly ISortHelper sortHelper;
        public BubbleSortSecvential(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunBubbleSort(string inputFilePath)
        {
            ArgumentNullException.ThrowIfNull(inputFilePath);

            int[] arr = sortHelper.ReadDataFromFile(inputFilePath);


            if (arr is null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return -1;
            }

         
            sortHelper.PrintArray(arr, "Array before sorting: ");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();

            sortHelper.PrintArray(arr, "Array after sorting: ");

            double executionTime = stopwatch.Elapsed.TotalSeconds;
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