
//insertion sort algorithm (ascending order)

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

                decimal[] sortedArray = InsertionSortASC(array);

                Console.WriteLine("\nSorted Array:");
                PrintArray(sortedArray);
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

        public static decimal[] InsertionSortASC(decimal[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                decimal key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }

            return array;
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
