using BenchmarkDotNet.Attributes;
using MEPSortingAlgorithms.algorith.seqvential;
using MEPSortingAlgorithms.implementation.parallel;
using MEPSortingAlgorithms.utils;
using MEPSortingAlgorithms.utils.iface;


namespace MEPSortingAlgorithms
{
    public class Benchmark
    {
        private ISortHelper sortHelper;
        private Constants constants;

        [GlobalSetup]
        public void Setup()
        {
            // Initialize helpers and constants
            sortHelper = new SortHelper();
            constants = new Constants();
        }

        [Benchmark]
        public void BubbleSortSequential()
        {
            var bubbleSort = new BubbleSortSecvential(sortHelper);
            bubbleSort.RunBubbleSort(constants.filePath);
        }

        [Benchmark]
        public void QuickSortSequential()
        {
            var quickSort = new QuickSortSecvential(sortHelper);
            quickSort.RunQuickSort(constants.filePath);
        }

        [Benchmark]
        public void SelectionSortSequential()
        {
            var selectionSort = new SelectionSortSecvential(sortHelper);
            selectionSort.RunSelectionSort(constants.filePath);
        }

        [Benchmark]
        public void BubbleSortParallel()
        {
            var bubbleSortParallel = new BubbleSortParallel(sortHelper);
            bubbleSortParallel.RunParallelBubbleSort(constants.filePath);
        }

        [Benchmark]
        public void QuickSortParallel()
        {
            var quickSortParallel = new QuickSortParallel(sortHelper);
            quickSortParallel.RunParallelQuickSort(constants.filePath);
        }

        [Benchmark]
        public void SelectionSortParallel()
        {
            var selectionSortParallel = new SelectionSortParallel(sortHelper);
            selectionSortParallel.RunParallelSelectionSort(constants.filePath);
        }
    }

}