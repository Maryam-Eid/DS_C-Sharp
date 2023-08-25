
//linear search

using System;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Linear Search Program!\n");
            Console.WriteLine("Please Enter The Array Elements Separated By Spaces:");

            try
            {
                string[] inputValues = Console.ReadLine().Split();
                int[] array = ParseArray(inputValues);

                Console.WriteLine("Enter The Number You Want To Search For:");
                int target = int.Parse(Console.ReadLine());

                int index = LinearSearch(array, target);

                if (index != -1)
                {
                    Console.WriteLine($"Found {target} At Index {index}.");
                }
                else
                {
                    Console.WriteLine($"{target} Not Found In The Array.");
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

        public static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i; 
                }
            }
            return -1; 
        }
    }
}
