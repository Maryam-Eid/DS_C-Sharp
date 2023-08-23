
//counting sort algorithm (ascending order)

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

                CountingSortASC(array);

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

        public static void CountingSortASC(decimal[] array)
        {
            decimal max = FindMax(array);

            decimal[] countArray = new decimal[(int)max + 1];
            for (int i = 0; i < array.Length; i++)
            {
                countArray[(int)array[i]]++;
            }

            int index = 0;
            for (int i = 0; i < countArray.Length; i++)
            {
                while (countArray[i] > 0)
                {
                    array[index] = i;
                    index++;
                    countArray[i]--;
                }
            }
        }

        public static decimal FindMax(decimal[] array)
        {
            decimal max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
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
