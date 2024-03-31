using MEPSortingAlgorithms.utils.iface;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MEPSortingAlgorithms.implementation.parallel
{
    public class BubbleSortParallel
    {
        private readonly ISortHelper sortHelper;
        public BubbleSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunParallelBubbleSort(string inputFilePath)
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
            ParallelBubbleSortAlgorithm(arr);
            stopwatch.Stop();

            sortHelper.PrintArray(arr, "Array after sorting: ");

            double executionTime = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"\nTime taken to sort: {executionTime} seconds");
            return executionTime;
        }

        private void ParallelBubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            Task[] tasks = new Task[n - 1]; // A task for each iteration of the outer loop

            for (int i = 0; i < n - 1; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            // Swap arr[j] and arr[j+1]
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                });
            }

            // Wait for all tasks to finish before continuing
            Task.WaitAll(tasks);
        }
    }
}
