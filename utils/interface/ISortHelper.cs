namespace MEPSortingAlgorithms.utils.iface
{
    public interface ISortHelper
    {
        int[]? ReadDataFromFile(string filePath);
        void PrintArray(int[] arr, string message);
    }
}
