using MEPSortingAlgorithms.utils.iface;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MEPSortingAlgorithms.implementation.parallel
{
    public class QuickSortParallel
    {
        private readonly ISortHelper sortHelper;
        public QuickSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunParallelQuickSort(string inputFilePath)
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
            ParallelQuickSortAlgorithm(arr, 0, arr.Length - 1);
            stopwatch.Stop();

            sortHelper.PrintArray(arr, "Array after sorting: ");

            double executionTime = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"\nTime taken to sort: {executionTime} seconds");
            return executionTime;
        }

        private void ParallelQuickSortAlgorithm(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = ParallelPartition(arr, low, high);

                // Create two tasks for sorting the left and right sublists of the partition
                Task leftTask = Task.Run(() => ParallelQuickSortAlgorithm(arr, low, partitionIndex - 1));
                Task rightTask = Task.Run(() => ParallelQuickSortAlgorithm(arr, partitionIndex + 1, high));

                // Wait for both tasks to finish
                Task.WaitAll(leftTask, rightTask);
            }
        }

        private int ParallelPartition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    // Swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Swap arr[i+1] and arr[high] (or pivot)
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
}
