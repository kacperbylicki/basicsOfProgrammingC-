using System;

namespace zadanie_5
{
    class Program
    {
        private static uint TestParse(string number)
        {
            if (uint.TryParse(number, out uint numberUint) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu uint");
                Environment.Exit(0); 
            }

            return numberUint;
        }
        
        // don't know how to name this method so it's ShowNumbers :)
        private static void ShowNumbers(uint number)
        {
            Console.Write("Liczby parzyste: ");
            for (uint i = 1; i <= number; i++)
            {
                if (i % 2 == 0) Console.Write($"[{i}]");
            }
            
            Console.WriteLine();
            
            Console.Write("Liczby nieparzyste: ");
            for (uint j = 1; j <= number; j++)
            {
                if (j % 2 == 1) Console.Write($"[{j}]");
            }
        }
        
        private static void Main(string[] args)
        {
            Console.Write("Podaj dodatnią liczbę całkowitą: ");
            uint naturalNumber = TestParse(Console.ReadLine());
            
            ShowNumbers(naturalNumber);
        }
    }
}
