using MEPSortingAlgorithms.utils.iface;
using OfficeOpenXml;

namespace MEPSortingAlgorithms.utils
{
    public class ExecutionTimeManager : IExecutionTimeManager
    {
        public void AddExecutionTimeToExcelSheet(ExcelPackage excel, string algorithmName, double executionTime, string sheetName = "Execution Times")
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
