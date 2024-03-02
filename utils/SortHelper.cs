namespace MEPSortingAlgorithms.utils
{
    public class SortHelper : ISortHelper
    {
        public void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public int[]? ReadDataFromFile(string filePath)
        {
            try
            {
                string[] data = File.ReadAllText(filePath).Trim().Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int[] arr = new int[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    if (!int.TryParse(data[i], out arr[i]))
                    {
                        Console.WriteLine($"Invalid data encountered: {data[i]}. Ensure the file contains only integers.");
                        return null;
                    }
                }
                return arr;
            }
            catch (Exception ex) when (ex is IOException or FormatException)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return null;
            }
        }
    }
}
