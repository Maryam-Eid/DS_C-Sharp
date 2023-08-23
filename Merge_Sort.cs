
//merge sort algorithm (ascending order)

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

                decimal[] sortedArray = MergeSortASC(array);

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

        public static decimal[] MergeSortASC(decimal[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            decimal[] left = new decimal[middle];
            decimal[] right = new decimal[array.Length - middle];

            Array.Copy(array, left, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            left = MergeSortASC(left);
            right = MergeSortASC(right);

            return Merge(left, right);
        }

        public static decimal[] Merge(decimal[] left, decimal[] right)
        {
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            decimal[] result = new decimal[left.Length + right.Length];

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }

            return result;
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
