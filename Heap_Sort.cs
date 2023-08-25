
//heap sort algorithm (ascending order)

using System;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Array Sorting Program!\n");
            Console.WriteLine("Please Enter The Array Elements Separated By Spaces:");

            try
            {
                string[] inputValues = Console.ReadLine().Split();

                int[] array = ParseArray(inputValues);

                HeapSortASC(array);

                Console.WriteLine("\nSorted Array:");
                PrintArray(array);
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error Occurred: " + e.Message);
            }
        }

        public static int[] ParseArray(string[] inputValues)
        {
            int[] array = new int[inputValues.Length];
            for (int i = 0; i < inputValues.Length; i++)
            {
                array[i] = int.Parse(inputValues[i]);
            }
            return array;
        }

        public static void HeapSortASC(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                Heapify(array, i, 0);
            }
        }

        public static void Heapify(int[] array, int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                Swap(ref array[root], ref array[largest]);
                Heapify(array, n, largest);
            }
        }

        static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.WriteLine(num);
            }
        }
    }
}
