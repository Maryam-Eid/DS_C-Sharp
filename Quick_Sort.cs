
//quick sort algorithm (ascending order)

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

                decimal[] array = ParseArray(inputValues);

                QuickSortASC(array, 0, array.Length - 1);

                Console.WriteLine("\nSorted Array:");
                PrintArray(array);
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error Occurred: " + e.Message);
            }
        }

        public static decimal[] ParseArray(string[] inputValues)
        {
            decimal[] array = new decimal[inputValues.Length];
            for (int i = 0; i < inputValues.Length; i++)
            {
                array[i] = decimal.Parse(inputValues[i]);
            }
            return array;
        }

        public static void QuickSortASC(decimal[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);

                QuickSortASC(array, low, pivot - 1);
                QuickSortASC(array, pivot + 1, high);
            }
        }

        public static int Partition(decimal[] array, int low, int high)
        {
            decimal pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        static void Swap(ref decimal first, ref decimal second)
        {
            decimal temp = first;
            first = second;
            second = temp;
        }

        static void PrintArray(decimal[] array)
        {
            foreach (decimal num in array)
            {
                Console.WriteLine(num);
            }
        }
    }
}
