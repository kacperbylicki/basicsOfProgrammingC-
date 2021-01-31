using System;
using System.IO;

namespace kolokwium_2
{
    class Program
    {
        private static int ParseInt(string input)
        {
            if (int.TryParse(input, out int integer) == false)
            {
                Console.Write("oczekiwano typu int");
                return 0; 
            }

            return integer;
        }
        
        private static float ParseFloat(string input)
        {
            if (float.TryParse(input, out float outFloat) == false)
            {
                Console.Write("oczekiwano typu int");
                return 0; 
            }

            return outFloat;
        }

        private static void ReadFile(string filename)
        {
            try
            {
                string[] file = File.ReadAllLines($@"C:\Users\PC\Desktop\{filename}");

                //Przechodzę przez wszystkie elementy tablicy file 
                foreach (string fileLine in file)
                {
                    Console.WriteLine(fileLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Brak pliku {e}");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Brak uprawnień do pliku {e}");
                Environment.Exit(0);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine($"Ścieżka za długa {e}");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Błąd podczas otwierania pliku {e}");
                Environment.Exit(0);
            }
        }

        private static void WriteFile(string[] array, string filename)
        {
            try
            {
                using (TextWriter tw = new StreamWriter($@"C:\Users\PC\Desktop\{filename}"))
                {
                    foreach (string element in array)
                    {
                        tw.WriteLine(element);
                    }
                }
            } catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Brak folderu {e}");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Brak uprawnień do zapisu pliku {e}");
                Environment.Exit(0);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine($"Ścieżka za długa {e}");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Błąd podczas zapisu pliku {e}");
                Environment.Exit(0);
            }
        }
        
        static void Main(string[] args)
        {
            // Odczyt już zapisanego wcześniej pliku
            ReadFile("plik1.txt");
            
            // Zapis danych 
            string[] array = {"sdasds", "asdasdsadasd", "asdasdsada"};
            WriteFile(array, "plik2.txt");
            ReadFile("plik2.txt");
        }
    }
}
