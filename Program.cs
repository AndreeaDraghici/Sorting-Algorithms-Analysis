using MEPSortingAlgorithms.implementation;
using MEPSortingAlgorithms.utils;
using MEPSortingAlgorithms.utils.iface;

namespace MEPSortingAlgorithms
{
    public class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                ISortHelper sortHelper = new SortHelper();
                IExecutionTimeManager executionTimeManager = new ExecutionTimeManager();
                Constants constants = new Constants();

                SeqventialSortingManager executeSorting = new SeqventialSortingManager(sortHelper, constants.filePath, executionTimeManager);
                executeSorting.RunAndExportSortingAlgorithms(constants.secventialOutputPath);

                Console.WriteLine("Sorting algorithms executed and results exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the execution: {ex.Message}");
            }
        }
    }
}