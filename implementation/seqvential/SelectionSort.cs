using MEPSortingAlgorithms.utils.iface;
using System.Diagnostics;

namespace MEPSortingAlgorithms.algorith.seqvential
{
    public class SelectionSort
    {
        private readonly ISortHelper sortHelper;

        public SelectionSort(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunSelectionSort(string inputFilePath)
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
            SelectionSortAlgorithm(arr);
            stopwatch.Stop();

            Console.WriteLine("\nArray after sorting:");
            sortHelper.PrintArray(arr);

            double executionTime = stopwatch.Elapsed.TotalSeconds * 10;
            Console.WriteLine($"\nTime taken to sort: {stopwatch.Elapsed.TotalSeconds * 10} seconds");

            return executionTime;
        }

        private void SelectionSortAlgorithm(int[] arr)
        {
            int size = arr.Length;

            // Loop through the array elements.
            for (int i = 0; i < size - 1; i++)
            {
                // Assume the minimum is the first element of the unsorted part.
                int minIndex = i;

                // Search the rest of the array to find the actual minimum.
                for (int idx = i + 1; idx < size; idx++)
                {
                    // If a smaller element is found, update minIndex with its index.
                    if (arr[idx] < arr[minIndex])
                    {
                        minIndex = idx;
                    }
                }

                // Swap the found minimum element with the first element of the unsorted part.
                // This effectively grows the sorted part of the array by one element.
                (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
            }
        }
    }
}