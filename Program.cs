using MEPSortingAlgorithms.utils;
using MEPSortingAlgorithms.algorith;
using MEPSortingAlgorithms.utils.iface;
using MEPSortingAlgorithms.implementation;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;


namespace MEPSortingAlgorithms
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1: Generate Random Input Data");
                Console.WriteLine("2: Execute Sequential Sorting");
                Console.WriteLine("3: Execute Parallel Sorting");
                Console.WriteLine("4: Run Benchmarks");
                Console.WriteLine("5: Exit");
                Console.Write("Select an option (1-5): ");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string option = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                switch (option)
                {
                    case "1":
                        GenerateRandomInputData();
                        break;
                    case "2":
                        await ExecuteSequentialSorting();
                        break;
                    case "3":
                        await ExecuteParallelSorting();
                        break;
                    case "4":
                        RunBenchmarks();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private static void GenerateRandomInputData()
        {
            try
            {
                Console.Write("Enter the number of data sets to generate: ");
                int numberOfDataSets = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter the number of elements per data set: ");
                int numberOfElements = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter the maximum value for elements: ");
                int maxValue = int.Parse(Console.ReadLine() ?? "0");

                RandomGenerator generator = new RandomGenerator();
                Constants constants = new Constants();

                for (int i = 0; i < numberOfDataSets; i++)
                {
                    string filePath = $"{constants.filePath}_set{i + 1}.txt";
                    generator.generateInputDataSet(numberOfElements, maxValue, filePath);
                    Console.WriteLine($"Data set {i + 1} generated successfully and saved to {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the data generation: {ex.Message}");
            }
        }

        private static Task ExecuteSequentialSorting()
        {
            try
            {
                ISortHelper sortHelper = new SortHelper();
                IExecutionTimeManager executionTimeManager = new ExecutionTimeManager();
                Constants constants = new Constants();

                SeqventialSortingManager sequentialSorting = new SeqventialSortingManager(sortHelper, constants.filePath, executionTimeManager);
                sequentialSorting.RunAndExportSortingAlgorithms(constants.secventialOutputPath);
                Console.WriteLine("Sequential sorting algorithms executed and results exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the sequential sorting execution: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        private static async Task ExecuteParallelSorting()
        {
            try
            {
                ISortHelper sortHelper = new SortHelper();
                IExecutionTimeManager executionTimeManager = new ExecutionTimeManager();
                Constants constants = new Constants();

                ParallelSortingManager parallelSorting = new ParallelSortingManager(sortHelper, constants.filePath, executionTimeManager);
                await parallelSorting.RunAndExportSortingAlgorithmsAsync(constants.parallelOutputPath);
                Console.WriteLine("Parallel sorting algorithms executed and results exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the parallel sorting execution: {ex.Message}");
            }
        }

        private static void RunBenchmarks()
        {
            var config = ManualConfig.Create(DefaultConfig.Instance)
               .WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(Perfolizer.Horology.TimeUnit.Second))
               .AddColumn(new SecondsTimeFormatter());

            var summary = BenchmarkRunner.Run<Benchmark>(config);
            Console.WriteLine(summary);
        }
    }
}
