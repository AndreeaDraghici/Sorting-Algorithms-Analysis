using MEPSortingAlgorithms.implementation.parallel;
using MEPSortingAlgorithms.utils.iface;
using OfficeOpenXml;


namespace MEPSortingAlgorithms.implementation
{
    public class ParallelSortingManager
    {
        private readonly ISortHelper sortHelper;
        private readonly string filePath;
        private readonly IExecutionTimeManager executionTimeManager;

        public ParallelSortingManager(ISortHelper sortHelper, string filePath, IExecutionTimeManager executionTimeManager)
        {
            this.sortHelper = sortHelper;
            this.filePath = filePath;
            this.executionTimeManager = executionTimeManager;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task RunAndExportSortingAlgorithmsAsync(string outputExcelPath)
        {
            try
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    // Initialize sorting algorithms
                    BubbleSortParallel bubbleSort = new BubbleSortParallel(sortHelper);
                    SelectionSortParallel selectionSort = new SelectionSortParallel(sortHelper);
                    QuickSortParallel quickSort = new QuickSortParallel(sortHelper);

                    // Execute sorting algorithms in parallel and capture execution times
                    Task<double> bubbleSortTask = Task.Run(() => bubbleSort.RunParallelBubbleSort(filePath));
                    Task<double> selectionSortTask = Task.Run(() => selectionSort.RunParallelSelectionSort(filePath));
                    Task<double> quickSortTask = Task.Run(() => quickSort.RunParallelQuickSort(filePath));

                    await Task.WhenAll(bubbleSortTask, selectionSortTask, quickSortTask);

                    // Add execution times to the Excel sheet
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "BubbleSort", bubbleSortTask.Result);
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "SelectionSort", selectionSortTask.Result);
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "QuickSort", quickSortTask.Result);

                    // Save the Excel file
                    FileInfo fileInfo = new FileInfo(outputExcelPath);
                    excel.SaveAs(fileInfo);
                    Console.WriteLine("Excel file saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
