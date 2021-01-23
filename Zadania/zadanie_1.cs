using System;
using System.ComponentModel.DataAnnotations;

namespace zadanie_1
{
    class Program
    {
        private static float TestParse(string number)
        {
            if (float.TryParse(number, out float numberFloat) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu float");
                Environment.Exit(0);
            }

            return numberFloat;
        }

        private static float SquareExpression(float expression)
        {
            return expression * expression;
        }
        
        private static float CalculateExpression(float firstNumber, float secondNumber)
        {
            float result = (secondNumber - SquareExpression(firstNumber - secondNumber)) / (2 * firstNumber);

            return result;
        }
        
        private static void Main(string[] args)
        {
            Console.Write("Podaj liczbę a: ");
            float firstNumber = TestParse(Console.ReadLine());

            if (firstNumber == 0 || firstNumber == 0.0)
            {
                Console.WriteLine("Próba dzielenia przez 0");
                return;
            }
            
            Console.Write("Podaj liczbę b: ");
            float secondNumber = TestParse(Console.ReadLine());
            
            float result = CalculateExpression(firstNumber, secondNumber);

            Console.WriteLine($"Wartość wyrażenia wynosi: {result}");
        }
    }
}
