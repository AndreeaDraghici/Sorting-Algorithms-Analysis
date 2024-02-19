using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEPSortingAlgorithms
{
    public class RandomGenerator
    {
        public void generateInputData(int dataSize)
        {
            Random random = new Random();

            int[] arr = new int[dataSize];

            // Generarea setului de date aleatoriu
            for (int i = 0; i < dataSize; i++)
            {
                arr[i] = random.Next(150); // Generează un număr aleatoriu între 0 și 149
            }

            // Scrierea setului de date în fișier
            string filePath = "D:\\Data\\Work\\Proiect MEP\\MEPSortingAlgorithms\\MEPSortingAlgorithms\\input\\data10000.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int num in arr)
                {
                    writer.Write(num + " ");
                }
            }

            Console.WriteLine("Data has been written to " + filePath);
        }
    }
}
