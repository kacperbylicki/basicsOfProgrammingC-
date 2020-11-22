using System;

namespace zadanie_6
{
    class Program
    {
        private static uint TestParseUint(string number)
        {
            if (uint.TryParse(number, out uint numberUint) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu uint");
                Environment.Exit(0); 
            }

            return numberUint;
        }
        
        private static float TestParseFloat(string number)
        {
            if (float.TryParse(number, out float numberFloat) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu float");
                Environment.Exit(0); 
            }

            if (numberFloat <= 0)
            {
                Console.Write("Twój wzrost nie może być <= 0");
                Environment.Exit(0);
            }

            return numberFloat;
        }

        private static void CalculateBmi(uint weight, float height)
        {
            float bmi = weight / (height * height);

            if (bmi < 18.5)
            {
                Console.WriteLine($"Twój BMI wynosi {bmi} i masz niedowagę.");
            } 
            else if (bmi >= 18.5 && bmi < 25)
            {
                Console.WriteLine($"Twój BMI wynosi {bmi} i masz prawidłową wagę.");
            }
            else if (bmi >= 25 && bmi < 30)
            {
                Console.WriteLine($"Twój BMI wynosi {bmi} i masz nadwagę.");
            }
            else
            {
                Console.WriteLine($"Twój BMI wynosi {bmi} i masz problem z otyłością - czas na dietę.");
            }
        }
        
        private static void Main(string[] args)
        {
            Console.Write("Podaj wagę w kilogramach: ");
            uint weight = TestParseUint(Console.ReadLine());

            Console.Write("Podaj wzrost w metrach: ");
            float height = TestParseFloat(Console.ReadLine());
            
            CalculateBmi(weight, height);
        }
    }
}
