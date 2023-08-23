
//selection sort algorithm (ascending order)

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

                decimal[] sortedArray = SelectionSortASC(array);

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

        public static decimal[] SelectionSortASC(decimal[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(ref array[i], ref array[min]);
                }
            }

            return array;
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
