using System;

namespace zadanie_3
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

        private static void IsPerfect(int number)
        {
            int divSum = 0;
            int i = 1;
            
            while (i <= number / 2)
            {
                if (number % i == 0)
                {
                    divSum += i;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine(number == divSum
                ? $"Podana liczba {number} jest liczbą doskonałą"
                : $"Podana liczba {number} nie jest liczbą doskonałą");
        }
        
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę: ");
            int number = TestParse(Console.ReadLine());
            
            IsPerfect(number);
        }
    }
}
