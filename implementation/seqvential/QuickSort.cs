using MEPSortingAlgorithms.utils.iface;
using System.Diagnostics;

namespace MEPSortingAlgorithms.algorith.seqvential
{
    public class QuickSort
    {
        private readonly ISortHelper sortHelper;

        public QuickSort(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunQuickSort(string inputFilePath)
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
            QuickSortAlgorithm(arr, 0, arr.Length - 1);
            stopwatch.Stop();

            Console.WriteLine("\nArray after sorting:");
            sortHelper.PrintArray(arr);
            double executionTime = stopwatch.Elapsed.TotalSeconds * 10;

            Console.WriteLine($"\nTime taken to sort: {executionTime} seconds");

            return executionTime;
        }

        private void QuickSortAlgorithm(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = Partition(arr, low, high);

                // Applies Quick Sort to the sub-array on the left of the pivot.
                QuickSortAlgorithm(arr, low, mid - 1);
                // Applies Quick Sort to the sub-array on the right of the pivot.
                QuickSortAlgorithm(arr, mid + 1, high);
            }
        }

        // Method for partitioning the array using a pivot.
        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            // Rearranges elements so that those smaller than the pivot are on the left of it and those larger are on the right.
            for (int idx = low; idx < high; idx++)
            {
                // If current element is smaller than the pivot
                if (arr[idx] < pivot)
                {
                    // increment index of smaller element
                    i++;

                    // Swap arr[i] and arr[idx]
                    (arr[i], arr[idx]) = (arr[idx], arr[i]);
                }
            }
            // Swap the pivot element with the element at i+1 position
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);

            // Return the partitioning index
            return i + 1;
        }
    }
}
