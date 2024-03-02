using MEPSortingAlgorithms.algorith.seqvential;
using MEPSortingAlgorithms.utils;
using OfficeOpenXml;


namespace MEPSortingAlgorithms.implementation
{
    public class SeqventialSortingManager
    {
        private readonly ISortHelper sortHelper;
        private readonly string filePath;

        public SeqventialSortingManager(ISortHelper sortHelper, string filePath)
        {
            this.sortHelper = sortHelper;
            this.filePath = filePath;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void RunAndExportSortingAlgorithms(string outputExcelPath)
        {
            try
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    // Initialize sorting algorithms
                    BubbleSort bubbleSort = new BubbleSort(sortHelper);
                    SelectionSort selectionSort = new SelectionSort(sortHelper);
                    QuickSort quickSort = new QuickSort(sortHelper);

                    // Execute sorting algorithms and capture execution times
                    double bubbleTime = bubbleSort.RunBubbleSort(filePath);
                    double selectionTime = selectionSort.RunSelectionSort(filePath);
                    double quickTime = quickSort.RunQuickSort(filePath);

                    // Add execution times to the Excel sheet
                    AddExecutionTimeToExcelSheet(excel, "BubbleSort", bubbleTime);
                    AddExecutionTimeToExcelSheet(excel, "SelectionSort", selectionTime);
                    AddExecutionTimeToExcelSheet(excel, "QuickSort", quickTime);

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

        private static void AddExecutionTimeToExcelSheet(ExcelPackage excel, string algorithmName, double executionTime, string sheetName = "Execution Times")
        {
            try
            {
                // Attempt to access or create the worksheet
                var worksheet = excel.Workbook.Worksheets[sheetName] ?? excel.Workbook.Worksheets.Add(sheetName);
                int row = worksheet.Dimension?.Rows + 1 ?? 1; // Calculate the next available row

                // If it's the first row, add headers
                if (row == 1)
                {
                    worksheet.Cells["A1"].Value = "Algorithm";
                    worksheet.Cells["B1"].Value = "Execution Time (Seconds)";
                    row++; // Increment row to ensure data starts from the second row
                }

                // Add algorithm name and execution time to the sheet
                worksheet.Cells[row, 1].Value = algorithmName;
                worksheet.Cells[row, 2].Value = executionTime;
            }
            catch (Exception ex)
            {
                // Log or handle the error appropriately
                Console.WriteLine($"An error occurred while adding data to the sheet '{sheetName}': {ex.Message}");
            }
        }
    }
}
