using System;
using System.Collections.Generic;

namespace zadanie_2
{
    class Program
    {
        private static int TestParse(string number)
        {
            if (int.TryParse(number, out int numberInt) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu integer");
                Environment.Exit(0);
            }

            return numberInt;
        }

        private static int[] Sort(int[] array)
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
        
        private static void Main(string[] args)
        {
            Console.Write("Podaj liczbę a: ");
            int firstNumber = TestParse(Console.ReadLine());
            
            Console.Write("Podaj liczbę b: ");
            int secondNumber = TestParse(Console.ReadLine());
            
            Console.Write("Podaj liczbę c: ");
            int thirdNumber = TestParse(Console.ReadLine());

            int[] array = new int[3] {firstNumber, secondNumber, thirdNumber};

            int[] sortedArray = Sort(array);
            
            Console.WriteLine($"Największa liczba to {sortedArray[2]}, a najmniejsza to {sortedArray[0]}");
        }
    }
}
