using System;

namespace LCM
{
    class Program
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
    
            private static uint CalculateGcd(uint firstNumber, uint secondNumber)
            {
                while (firstNumber != secondNumber)
                {
                    if (firstNumber > secondNumber)
                    {
                        firstNumber -= secondNumber;
                    }
                    else
                    {
                        secondNumber -= firstNumber;
                    }
                }
    
                return firstNumber;
            }

            private static uint CalculateLcm(uint firstNumber, uint secondNumber)
            {
                uint gcd = CalculateGcd(firstNumber, secondNumber);

                return (firstNumber * secondNumber) / gcd;
            }
    
            static void Main(string[] args)
            {
                Console.Write("Enter first number: ");
                uint firstNumber = TestParse(Console.ReadLine());
                
                Console.Write("Enter second number: ");
                uint secondNumber = TestParse(Console.ReadLine());
    
                uint lcm = CalculateLcm(firstNumber, secondNumber);
                Console.WriteLine($"Least Common Multiple for {firstNumber} and {secondNumber} is {lcm}.");
            }
        }
}
