using System;

namespace bubbleSort
{
    class Program
    {
        private static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            return array;
        }

        private static void ShowArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }
        }
        
        static void Main(string[] args)
        {
            int[] array = new int [10] {4, 1, 63, 21, 19, 98, 17, 9, 0, 54};

            int[] sortedArray = BubbleSort(array);
            
            ShowArray(sortedArray);
        }
    }
}
