using MEPSortingAlgorithms.implementation;
using MEPSortingAlgorithms.utils;

namespace MEPSortingAlgorithms
{
    public class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                ISortHelper sortHelper = new SortHelper();
                Constants constants = new Constants();

                SeqventialSortingManager executeSorting = new SeqventialSortingManager(sortHelper, constants.filePath);
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