using OfficeOpenXml;

namespace MEPSortingAlgorithms.utils.iface
{
    public interface IExecutionTimeManager
    {
        void AddExecutionTimeToExcelSheet(ExcelPackage excel, string algorithmName, double executionTime, string sheetName = "Execution Times");
    }
}
