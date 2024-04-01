using MEPSortingAlgorithms.implementation;
using MEPSortingAlgorithms.utils;
using MEPSortingAlgorithms.utils.iface;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MEPSortingAlgorithms
{
    public class Program
    {


        public static void Main(string[] args)
        {
            try
            {
                // Initialization
                ISortHelper sortHelper = new SortHelper();
                IExecutionTimeManager executionTimeManager = new ExecutionTimeManager();
                Constants constants = new Constants();

                // Sequential sorting execution
                SeqventialSortingManager sequentialSorting = new SeqventialSortingManager(sortHelper, constants.filePath, executionTimeManager);
                sequentialSorting.RunAndExportSortingAlgorithms(constants.secventialOutputPath);
                Console.WriteLine("Sequential sorting algorithms executed and results exported successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the execution: {ex.Message}");
            }
        }



        /* public static async Task Main(string[] args)
         {
             try
             {
                 // Initialization
                 ISortHelper sortHelper = new SortHelper();
                 IExecutionTimeManager executionTimeManager = new ExecutionTimeManager();
                 Constants constants = new Constants();

                 // Parallel sorting execution
                 ParallelSortingManager parallelSorting = new ParallelSortingManager(sortHelper, constants.filePath, executionTimeManager);
                 await parallelSorting.RunAndExportSortingAlgorithmsAsync(constants.parallelOutputPath);
                 Console.WriteLine("\nParallel sorting algorithms executed and results exported successfully.");
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"An error occurred during the execution: {ex.Message}");
             }

         }*/
    }
}