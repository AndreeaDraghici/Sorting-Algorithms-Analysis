using System.Diagnostics;

namespace MEPSortingAlgorithms.seqvential
{
    public class BubbleSort
    {

        public BubbleSort() { }

        public static void RunBubbleSort(string inputFilePath)
        {

            // Citirea setului de date din fișier
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int[] arr = ReadDataFromFile(inputFilePath);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (arr == null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return;
            }

            // Afișarea setului de date inițial
            Console.WriteLine("Array before sorting:");
            PrintArray(arr);

            // Sortarea setului de date folosind Bubble Sort și măsurarea timpului de execuție
            Stopwatch stopwatch = new();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Afișarea setului de date sortat și timpul de execuție
            Console.WriteLine("\nArray after sorting:");
            PrintArray(arr);
            Console.WriteLine("\nTime taken to sort: " + (elapsedTime.TotalSeconds * 10) + " seconds");
        }

        private static int[]? ReadDataFromFile(string inputFilePath)
        {
            try
            {
                string[] data = File.ReadAllText(inputFilePath).Trim().Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
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

        private static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static void BubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    }
                }
            }
        }
    }
}