using System;

namespace zadanie_4
{
    class Program
    {
        private static uint TestParse(string number)
        {
            if (uint.TryParse(number, out uint numberUint) == false)
            {
                Console.WriteLine("Zły format - oczekiwano typu uint.");
                Environment.Exit(0);
            }

            return numberUint;
        }

        private static void ShowRectangle(uint width)
        {
            for (uint j = 0; j < width; j++)
            {
                for (uint i = 0; i < width; i++)
                {
                    Console.Write("#");
                }
                
                Console.WriteLine();
            }
        }
        
        private static void Main(string[] args)
        {
            Console.Write("Podaj długość krawędzi: ");
            uint rectWidth = TestParse(Console.ReadLine());

            if (rectWidth > 20)
            {
                Console.WriteLine($"Podana długość krawędzi ({rectWidth}) jest za duża. Maksymalna wartość to 20.");
            }
            else
            {
                ShowRectangle(rectWidth);
            }
        }
    }
}
