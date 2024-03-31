using MEPSortingAlgorithms.utils.iface;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MEPSortingAlgorithms.implementation.parallel
{
    public class SelectionSortParallel
    {
        private readonly ISortHelper sortHelper;
        public SelectionSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public double RunParallelSelectionSort(string inputFilePath)
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
            ParallelSelectionSortAlgorithm(arr);
            stopwatch.Stop();

            sortHelper.PrintArray(arr, "Array after sorting: ");

            double executionTime = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"\nTime taken to sort: {executionTime} seconds");
            return executionTime;
        }

        private void ParallelSelectionSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            // A task for each iteration of the outer loop
            Task[] tasks = new Task[n - 1]; 

            for (int i = 0; i < n - 1; i++)
            {
                // Saves the current index to avoid capturing the enclosed variable in the lambda
                int currentIndex = i; 
                tasks[i] = Task.Run(() =>
                {
                    // Finds the smallest element in the unsorted sublist
                    int minIndex = currentIndex;
                    for (int j = currentIndex + 1; j < n; j++)
                    {
                        if (arr[j] < arr[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    // Swap the smallest element with the first element in the unsorted sublist
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[currentIndex];
                    arr[currentIndex] = temp;

                });
            }

            // Wait for all tasks to finish before continuing
            Task.WaitAll(tasks);
        }
    }
}

