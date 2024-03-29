using System;
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 25, 12, 22, 11, 12, 35, 47, 91, 69, 42, 1, 53 };
            Console.WriteLine("Original Array:");
            PrintArray(array);
            BubbleSort bubbleSort = new BubbleSort();
            Console.WriteLine("\nSorting with Bubble Sort:");
            bubbleSort.Sort(array);
            PrintArray(array);
            InsertionSort insertionSort = new InsertionSort();
            Console.WriteLine("\nSorting with Insertion Sort:");
            insertionSort.Sort(array);
            PrintArray(array);
            SelectionSort selectionSort = new SelectionSort();
            Console.WriteLine("\nSorting with Selection Sort:");
            selectionSort.Sort(array);
            PrintArray(array);
        }
        static void PrintArray(int[] arr)
        {
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
    abstract class SortingAlgorithm
    {
        public void Sort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            SortArray(array);
        }
        protected abstract void SortArray(int[] array);
        protected void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
    class BubbleSort : SortingAlgorithm
    {
        protected override void SortArray(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }
    }
    class InsertionSort : SortingAlgorithm
    {
        protected override void SortArray(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
    }
    class SelectionSort : SortingAlgorithm
    {
        protected override void SortArray(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIdx])
                    {
                        minIdx = j;
                    }
                }
                Swap(array, i, minIdx);
            }
        }
    }
}