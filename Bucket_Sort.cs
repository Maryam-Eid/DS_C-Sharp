
//bucket sort algorithm (ascending order)

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

                BucketSortASC(array);

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

        public static void BucketSortASC(int[] array)
        {
            int maxVal = array.Max();
            int minVal = array.Min();
            int bucketCount = 10;

            List<int>[] buckets = new List<int>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (int num in array)
            {
                int bucketIndex = (num - minVal) * (bucketCount - 1) / (maxVal - minVal);
                buckets[bucketIndex].Add(num);
            }

            foreach (List<int> bucket in buckets)
            {
                bucket.Sort();
            }

            int index = 0;
            foreach (List<int> bucket in buckets)
            {
                foreach (int num in bucket)
                {
                    array[index++] = num;
                }
            }
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
