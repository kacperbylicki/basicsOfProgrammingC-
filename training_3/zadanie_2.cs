using System;

namespace kolokwium_2_zad_2
{
    internal static class StringExtentions
    {
        public static int ParseInt(this string instance)
        {
            if (int.TryParse(instance, out int numInt) == false)
            {
                Console.WriteLine("Niepoprawny typ. Oczekiwano typu int.");
                Environment.Exit(0);
            }

            return numInt;
        }
    }
    
    class Program
    {
        private static int[] FillArray(int arraySize)
        {
            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"Podaj element [{i + 1}]: ");
                int element = Console.ReadLine().ParseInt();
                array[i] = element;
            }

            return array;
        }
        
        private static bool IsDivider(ref int divider, int dividend)
        {
            return dividend % divider == 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Podaj rozmiar tablicy dzielników: ");
            int arraySize = Console.ReadLine().ParseInt();

            int[] array = FillArray(arraySize);

            Console.Write("Podaj liczbę do sprawdzenia: ");
            int divider = Console.ReadLine().ParseInt();

            for (int i = 0; i < arraySize; i++)
            {
                if (IsDivider(ref array[i], divider))
                {
                    Console.WriteLine("TAK");
                    Environment.Exit(0);
                }
            }
            
            Console.WriteLine("NIE");
        }
    }
}
