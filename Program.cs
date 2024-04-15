using MEPSortingAlgorithms.utils;
using MEPSortingAlgorithms.algorith;
using MEPSortingAlgorithms.utils.iface;
using MEPSortingAlgorithms.implementation;

namespace MEPSortingAlgorithms
{
    public class Program
    {

        /*  public static void Main(string[] args)
          {
              RandomGenerator generator = new RandomGenerator();
              Constants constants = new Constants();
              generator.generateInputDataSet(100000,100000, constants.filePath);

          }
  */

        /* public static void Main(string[] args)
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
         }*/


        public static async Task Main(string[] args)
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

        }
    }
}