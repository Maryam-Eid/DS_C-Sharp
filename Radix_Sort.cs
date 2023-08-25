
//radix sort algorithm (ascending order)

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

                RadixSortASC(array);

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

        public static void RadixSortASC(int[] array)
        {
            int max = FindMax(array);

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSortByDigit(array, exp);
            }
        }

        public static void CountingSortByDigit(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < 10; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                int digit = (array[i] / exp) % 10;
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (array[i] / exp) % 10;
                output[count[digit] - 1] = array[i];
                count[digit]--;
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }

        public static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
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
