### Homework 13
Performance analysis sorting algorithms in the C# language.


### Description
The problem studied in the context of the mentioned project focuses on the analysis performance of sorting algorithms in the C# programming language. This involves an investigation of three sorting algorithms to evaluate their effectiveness in execution time terms. The main objective is to identify the algorithm or algorithms sorting the most suitable for different types of data sets.

### Algorithms implemented
**Bubble Sort:** A simple comparison-based algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.

**Selection Sort:** This algorithm sorts an array by repeatedly finding the minimum element from the unsorted part and putting it at the beginning.

**Quick Sort:** An efficient, divide-and-conquer, comparison-based sorting algorithm. It picks an element as a pivot and partitions the given array around the picked pivot.

### Two approaches
Two main approaches were used to analyze the performance of the implemented algorithms:

- **Sequential Execution in C#:** Sorting operations are performed in a sequential manner, one after the other. This approach helps in understanding the basic performance characteristics of each algorithm.
- **Parallel Execution with C# Threads:** Utilizes C# threading to perform sorting operations in parallel, aiming to leverage multi-core processors for improved performance.



### Implementation details

1. Implemented Bubble Sort algorithm, Selection Sort algorithm and Quick Sort algorithm in C#.
2. Developed application that generates random data sets sizes and evaluates the sorting time for each algorithm using these data sets.
3. Measuring and comparing the sorting time of each algorithm for each scenario and dataset size.
4. The application generates random datasets of various sizes (e.g., 10, 100, 1.000, 10.000, 100.000 elements) for testing purposes.


### About Local Infrastructure
- CPU: Intel(R) Core(TM) i7-10870H @ 2.20 GHz
- GPU:  NVIDIA GeForce RTX 2060
