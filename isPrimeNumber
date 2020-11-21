using System;

namespace BeforeExam
{
    internal class Program
    {
        private static bool IsPrime(uint number)
        {
            if (number == 0 || number == 1 || number % 2 == 0) return false;
            if (number == 2) return true;

            uint boundary = (uint) Math.Floor(Math.Sqrt(number));

            for (uint i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        private static void Main(string[] args)
        {
            Console.Write("Input number: ");

            string number = Console.ReadLine();

            Console.WriteLine(
                uint.TryParse(number, out uint numberUint) == false
                    ? "Wrong Format -- Natural number expected"
                    : IsPrime(numberUint)
                        ? "Is prime number."
                        : "Is not prime number."
            );
        }
    }
}
