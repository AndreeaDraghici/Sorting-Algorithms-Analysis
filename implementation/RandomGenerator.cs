namespace MEPSortingAlgorithms.algorith
{
    public class RandomGenerator
    {
        public void generateInputDataSet(int dataSize, int randomMaxNumber, string generateIntoFile)
        {
            Random random = new();
            HashSet<int> uniqueNumbers = new();

            // Checks if the dataset size does not exceed the maximum number of unique random numbers possible
            if (dataSize > randomMaxNumber)
            {
                throw new ArgumentException("The dataset size cannot be greater than the maximum number of random numbers.");
            }

            // Continues generating numbers until the HashSet contains the desired amount of unique values
            while (uniqueNumbers.Count < dataSize)
            {
                // Attempts to add a new unique random number to the set
                uniqueNumbers.Add(random.Next(randomMaxNumber)); // Generates a random number between 0 and randomMaxNumber-1
            }

            // Writing the numbers to file
            using (StreamWriter writer = new(generateIntoFile))
            {
                foreach (int num in uniqueNumbers)
                {
                    writer.Write(num + " ");
                }
            }

            Console.WriteLine($"Data has been written to {generateIntoFile} with {dataSize} unique entries.");
        }
    }
}
