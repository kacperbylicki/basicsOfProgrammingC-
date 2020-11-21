using System;

namespace BeforeExam
{
    internal class Program
    {
        private static uint TestParse(string number)
        {
            if (uint.TryParse(number, out uint numberUint) == false)
            {
                Console.WriteLine("Wrong Format -- Natural number expected");
                Environment.Exit(0); 
            }

            return numberUint;
        }
        
        private static bool IsPrime(uint number)
        {
            if (number == 0 || number == 1 || number % 2 == 0) return false;
            if (number == 2) return true;

            uint boundary = (uint) Math.Floor(Math.Sqrt(number));

            for (uint i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static void Main(string[] args)
        {
            Console.Write("Input number: ");

            uint numberUint = TestParse(Console.ReadLine());
            
            // Ternary operator syntax
            Console.WriteLine(
                IsPrime(numberUint) 
                    ? $"{numberUint} is prime number." 
                    : $"{numberUint} is not prime number."
            );
        }
    }
}
