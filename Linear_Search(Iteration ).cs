
//binary search (iteration method)
using System;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Binary Search Program!\n");
            Console.WriteLine("Please Enter The Array Elements Separated By Spaces:");

            try
            {
                string[] inputValues = Console.ReadLine().Split();
                int[] array = ParseArray(inputValues);

                Console.WriteLine("Enter The Number You Want To Search For:");
                int target = int.Parse(Console.ReadLine());

                InsertionSort(array);

                int index = BinarySearch(array, target);

                if (index != -1)
                {
                    Console.WriteLine($"{target} Is Found.");
                }
                else
                {
                    Console.WriteLine($"{target} Is Not Found.");
                }
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

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    return mid; 
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1; 
                }
            }

            return -1; 
        }
    }
}

