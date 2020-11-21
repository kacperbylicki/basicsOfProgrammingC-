using System;

namespace ChristmasTree
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
        
        private static void ShowChristmasTree(uint treeHeight, uint trunkHeight)
        {
            for (uint height = 1; height <= treeHeight; height++)
            {
                for (uint index = treeHeight - height; index > 0; index--)
                {
                    Console.Write(" ");
                }

                for (uint branch = 0; branch < height; branch++)
                {
                    Console.Write( branch % 2 == 0 ? "* " : "o ");
                }
                
                Console.WriteLine();
            }

            for (uint height = 1; height <= trunkHeight; height++)
            {
                for (uint index = treeHeight - 1; index > 0; index--)
                {
                    Console.Write(" ");
                }
                
                Console.WriteLine("|");
            }
        }
        
        private static void Main(string[] args)
        {
            Console.Write("Enter tree height: ");

            uint treeHeightUint = TestParse(Console.ReadLine());

            Console.Write("Enter tree trunk height: ");

            uint treeTrunkHeightUint = TestParse(Console.ReadLine());
            
            ShowChristmasTree(treeHeightUint, treeTrunkHeightUint);
        }
    }
}
