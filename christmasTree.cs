using System;

namespace ChristmasTree
{
    class Program
    {
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

            string treeHeight = Console.ReadLine();

            if (uint.TryParse(treeHeight, out uint treeHeightUint) == false)
            {
                Console.WriteLine("Wrong Format -- Natural number expected");
                return;
            }
            
            Console.Write("Enter tree trunk height: ");

            string treeTrunkHeight = Console.ReadLine();

            if (uint.TryParse(treeTrunkHeight, out uint treeTrunkHeightUint) == false)
            {
                Console.WriteLine("Wrong Format -- Natural number expected");
            }
            else
            {
                ShowChristmasTree(treeHeightUint, treeTrunkHeightUint);
            }
        }
    }
}
