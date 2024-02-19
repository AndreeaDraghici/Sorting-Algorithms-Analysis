using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEPSortingAlgorithms.seqvential
{
    public class BubbleSort
    {

        public BubbleSort() { }

        public static void RunBubbleSort(string filePath)
        {

            // Citirea setului de date din fișier
            int[] arr = ReadDataFromFile(filePath);

            if (arr == null)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return;
            }

            // Afișarea setului de date inițial
            Console.WriteLine("Array before sorting:");
            PrintArray(arr);

            // Sortarea setului de date folosind Bubble Sort și măsurarea timpului de execuție
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSortAlgorithm(arr);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Afișarea setului de date sortat și timpul de execuție
            Console.WriteLine("\nArray after sorting:");
            PrintArray(arr);
            Console.WriteLine("\nTime taken to sort: " + elapsedTime.TotalSeconds + " seconds");
        }

        private static int[]? ReadDataFromFile(string filePath)
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
            catch (Exception ex) when (ex is IOException || ex is FormatException)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return null;
            }
        }

        private static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static void BubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
    }
}