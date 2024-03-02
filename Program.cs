using MEPSortingAlgorithms.seqvential;
using MEPSortingAlgorithms.utils;

namespace MEPSortingAlgorithms
{
    public class Program
    {
   
        public static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            Constants constants = new();

            // RandomGenerator generator = new RandomGenerator();

            // generator.generateInputDataSet(10000, 10000, constants.filePath); // Dimensiunea setului de date


            BubbleSort.RunBubbleSort(constants.filePath);
        }
    }
}