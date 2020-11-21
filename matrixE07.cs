using System;

namespace matrix_zd7
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
        
        private static double[,] FillMatrix(uint matrixDegree)
        {
            double[,] matrix = new double[matrixDegree, matrixDegree];
            
            for (uint i = 0; i < matrixDegree; i++)
            {
                for (uint j = 0; j < matrixDegree; j++)
                {
                    Console.Write($"Enter element [{i + 1},{j + 1}] = ");
                    matrix[i, j] = TestParse(Console.ReadLine());
                }
            }

            return matrix;
        }

        private static double SumUpperDiagonal(double[,] matrix, uint matrixDegree)
        {
            double upperSum = 0;

            for (uint i = 0; i < matrixDegree; i++)
            {
                for (uint j = 0; j < matrixDegree; j++)
                {
                    if (i < j) upperSum += matrix[i, j];
                }
            }

            return upperSum;
        }

        private static double SumLowerDiagonal(double[,] matrix, uint matrixDegree)
        {
            double lowerSum = 0;
            
            for (uint i = 0; i < matrixDegree; i++)
            {
                for (uint j = 0; j < matrixDegree; j++)
                {
                    if (i > j) lowerSum += matrix[i, j];
                }
            }

            return lowerSum;
        }

        private static void Main(string[] args)
        {
            Console.Write("Enter matrix degree: ");

            uint matrixDegree = TestParse(Console.ReadLine());

            double[,] filledMatrix = FillMatrix(matrixDegree);
            
            double upperSum = SumUpperDiagonal(filledMatrix, matrixDegree);
            double lowerSum = SumLowerDiagonal(filledMatrix, matrixDegree);

            string partOfString = upperSum < lowerSum ? "not" : "";
            
            Console.WriteLine($"Sum over main diagonal (= {upperSum}) is {partOfString} higher than sum under main diagonal (= {lowerSum})");
        }
    }
}
