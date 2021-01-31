using System;
using System.IO;
using System.Text.RegularExpressions;

namespace kolokwium_2
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

    internal static class TriangleExtensions
    {
        public static Program.Triangle TriangleExists(this Program.Triangle instance)
        {
            if (instance.A + instance.B < instance.C || 
                instance.B + instance.C < instance.A ||
                instance.A + instance.C < instance.B)
            {
                Console.WriteLine("Nie istnieje trójkąt o podanych bokach.");
                Environment.Exit(0);
            }

            return instance;
        }
    }

    class Program
    {
        public class Triangle
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }

            public Triangle(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
        
        private static int CalculateCircuit(Triangle triangle)
        {
            int circuit = triangle.A + triangle.B + triangle.C;

            return circuit;
        }
        
        static void Main(string[] args)
        {
            Console.Write("Podaj a: ");
            int a = Console.ReadLine().ParseInt();
            Console.Write("Podaj b: ");
            int b = Console.ReadLine().ParseInt();
            Console.Write("Podaj c: ");
            int c = Console.ReadLine().ParseInt();

            Triangle triangle = new Triangle(a, b, c).TriangleExists();
            int circuit = CalculateCircuit(triangle);
            
            Console.WriteLine($"Obwód trójkąta wynosi: {circuit}");
        }
    }
}
