using MEPSortingAlgorithms.algorith.seqvential;
using MEPSortingAlgorithms.utils.iface;
using OfficeOpenXml;


namespace MEPSortingAlgorithms.implementation
{
    public class SeqventialSortingManager
    {
        private readonly ISortHelper sortHelper;
        private readonly string filePath;
        private readonly IExecutionTimeManager executionTimeManager;

        public SeqventialSortingManager(ISortHelper sortHelper, string filePath, IExecutionTimeManager executionTimeManager)
        {
            this.sortHelper = sortHelper;
            this.filePath = filePath;
            this.executionTimeManager = executionTimeManager;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void RunAndExportSortingAlgorithms(string outputExcelPath)
        {
            try
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    // Initialize sorting algorithms
                    BubbleSortSecvential bubbleSort = new BubbleSortSecvential(sortHelper);
                    SelectionSortSecvential selectionSort = new SelectionSortSecvential(sortHelper);
                    QuickSortSecvential quickSort = new QuickSortSecvential(sortHelper);

                    // Execute sorting algorithms and capture execution times
                    double bubbleTime = bubbleSort.RunBubbleSort(filePath);
                    double selectionTime = selectionSort.RunSelectionSort(filePath);
                    double quickTime = quickSort.RunQuickSort(filePath);

                    // Add execution times to the Excel sheet
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "BubbleSort", bubbleTime);
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "SelectionSort", selectionTime);
                    executionTimeManager.AddExecutionTimeToExcelSheet(excel, "QuickSort", quickTime);

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