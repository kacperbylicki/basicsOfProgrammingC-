using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
// ReSharper disable FunctionNeverReturns

namespace ConsoleApplication1
{
    internal static class StringExtentions 
    { 
        public static int ParseInt(this string instance) 
        {
            if (int.TryParse(instance, out int numberInt) == false)
            {
                Console.WriteLine("Nie podano poprawnej liczby.");
                Environment.Exit(0);
            }

            return numberInt;
        }
        
        public static string NotEmptyString(this string instance)
        {
            if (instance == "")
            {
                Console.WriteLine("Łańcuch nie może być pusty.");
                Environment.Exit(0);
            }

            return instance;
        }
        
        
        public static string SanitizeString(this string instance)
        {
            return Regex.Replace(instance, @"[^0-9a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ,.?! ]+", "");
        }
    }

    internal static class IntExtensions
    {
        public static int FitsPageNumberRange(this int instance)
        {
            if (instance > 1000 || instance < 1)
            {
                Console.WriteLine("Liczba stron wychodzi poza zakres 1 - 1000");
                Environment.Exit(0);
            }

            return instance;
        }
        
        public static int FitsReleaseYearRange(this int instance)
        {
            if (instance > 2021 || instance < 1)
            {
                Console.WriteLine("Rok wydania wychodzi poza zakres 1 - 2021");
                Environment.Exit(0);
            }

            return instance;
        }
    }
    
    internal class Program
    {
        private class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int PageNumber { get; set; }
            public int ReleaseYear { get; set; }

            public Book(string title, string author, int pageNumber, int releaseYear)
            {
                Title = title;
                Author = author;
                PageNumber = pageNumber;
                ReleaseYear = releaseYear;
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Wybierz zadanie, które chcesz wykonać: ");
            Console.WriteLine("[1] Utwórz nowy katalog biblioteczny");
            Console.WriteLine("[2] Zapisz katalog do pliku");
            Console.WriteLine("[3] Odczytaj katalog z pliku");
            Console.WriteLine("[4] Wyszukaj książki w katalogu");
            Console.WriteLine("[5] Koniec");
        }

        private static List<Book> CreateCatalog()
        {
            Console.Write("\nPodaj liczbę książek, którą chcesz dodać do pliku: ");
            int quantity = Console.ReadLine().ParseInt();

            List<Book> booksList =  new List<Book>();

            for (int index = 0; index < quantity; index++)
            {
                Console.WriteLine($"\nKsiążka nr. {index + 1} \n");
                
                Console.Write("Podaj tytuł: ");
                string title = Console.ReadLine().NotEmptyString().SanitizeString();

                Console.Write("Podaj autora: ");
                string author = Console.ReadLine().NotEmptyString().SanitizeString();

                Console.Write("Podaj liczbę stron: ");
                int pageNumber = Console.ReadLine().ParseInt().FitsPageNumberRange();
                
                Console.Write("Podaj rok wydania: ");
                int releaseYear = Console.ReadLine().ParseInt().FitsReleaseYearRange();
                
                Book book = new Book(title, author, pageNumber, releaseYear);
                
                booksList.Add(book);
            }

            return booksList;
        }

        private static void WriteCatalog()
        {
            try
            {
                Console.Write("Podaj nazwę pliku katalogu: ");
                string catalogName = Console.ReadLine().NotEmptyString().SanitizeString();
            
                using (TextWriter tw = new StreamWriter($"/home/kacper/Documents/{catalogName}.txt"))
                {
                    _catalog.ForEach(item => tw.WriteLine(
                        string.Format($"{item.Title},{item.Author},{item.PageNumber},{item.ReleaseYear}"))
                    );
                }
                
                Console.WriteLine($"Katalog został zapisany pod nazwą {catalogName}.txt");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.Write($"Podana ścieżka nie istnieje. Error: {e}");
                Environment.Exit(0);
            }
            catch (ArgumentException e)
            {
                Console.Write($"Ścieżka nie może być pusta. Error: {e}");
                Environment.Exit(0);
            }
            catch (PathTooLongException e)
            {
                Console.Write($"Podana ścieżka jest za długa. Error: {e}");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.Write($"Wystąpił błąd podczas zapisu pliku. Error: {e}");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Write($"Brak uprawnień do zapisu pliku. Error: {e}");
                Environment.Exit(0);
            }
        }

        private static void ReadCatalog()
        {
            try
            {
                Console.Write("Podaj nazwę pliku katalogu: ");
                string catalogName = Console.ReadLine().NotEmptyString().SanitizeString();

                string[] lines = File.ReadAllLines($"/home/kacper/Documents/{catalogName}.txt");
                
                Console.WriteLine("\nTytuł, Autorzy, Liczba stron, Rok wydania");

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write($"Nie znaleziono pliku katalogu o podanej nazwie. Error: {e}");
                Environment.Exit(0);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.Write($"Podana ścieżka nie istnieje. Error: {e}");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.Write($"Wystąpił błąd podczas otwierania pliku. Error: {e}");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Write($"Brak uprawnień do otwarcia pliku. Error: {e}");
                Environment.Exit(0);
            }
        }

        private static void SearchInCatalog()
        {
            void ShowFound(List<Book> bookList, int countFound)
            {
                Console.WriteLine(countFound > 1 ? $"{countFound} wyniki: " : $"{countFound} wynik: ");

                foreach (Book book in bookList)
                {
                    Console.WriteLine($"Tytuł: { book.Title }");
                    Console.WriteLine($"Autor: { book.Author }");
                    Console.WriteLine($"Liczba stron: { book.PageNumber }");
                    Console.WriteLine($"Rok wydania: { book.ReleaseYear }");
                    Console.WriteLine();
                }
            } 
            
            try
            {
                Console.Write("Podaj nazwę pliku katalogu: ");
                string catalogName = Console.ReadLine().NotEmptyString().SanitizeString();
                
                string[] catalog = File.ReadAllLines($"/home/kacper/Documents/{catalogName}.txt");
                
                Console.Write("Podaj tytuł szukanej książki: ");
                string searchTitle = Console.ReadLine().NotEmptyString().SanitizeString();

                List<Book> catalogBooks = new List<Book>();

                foreach (string book in catalog)
                {
                    string[] bookArray = book.Split(',');

                    catalogBooks.Add(new Book (
                        bookArray[0], 
                        bookArray[1], 
                        bookArray[2].ParseInt(), 
                        bookArray[3].ParseInt()
                        )
                    );
                }
                
                int count = catalogBooks.Count(x => x.Title == searchTitle);

                if (count > 0)
                {
                    List<Book> foundBook = new List<Book>();

                    for (int i = 0; i < count; i++)
                    {
                        foundBook.Add(catalogBooks.Find(x => x.Title == searchTitle));
                        catalogBooks.Remove(catalogBooks.Find(x => x.Title == searchTitle));
                    }

                    Console.WriteLine("\nWyniki wyszukiwania: ");

                    ShowFound(foundBook, count);
                }
                else
                {
                    Console.WriteLine("Nie znaleziono szukanego tytułu.");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write($"Nie znaleziono pliku katalogu o podanej nazwie. Error: {e}");
                Environment.Exit(0);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.Write($"Podana ścieżka nie istnieje. Error: {e}");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.Write($"Wystąpił błąd podczas otwierania pliku. Error: {e}");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Write($"Brak uprawnień do otwarcia pliku. Error: {e}");
                Environment.Exit(0);
            }
        }
        
        private static List<Book> _catalog = new List<Book>();

        private static void Startup()
        {
            while (true)
            {
                ShowMenu();

                Console.Write("\nWybierz zadanie z menu: ");
                int choice = Console.ReadLine().ParseInt();

                switch (choice)
                {
                    case 1:
                        _catalog = CreateCatalog();
                        break;
                    case 2:
                        if (_catalog.Count > 0) WriteCatalog();
                        else Console.WriteLine("Brak katalogu do zapisania.");
                        break;
                    case 3:
                        ReadCatalog();
                        break;
                    case 4:
                        SearchInCatalog();
                        break;
                    case 5:
                        Console.WriteLine("Program kończy pracę.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nie wybrano poprawnego zadania. Program kończy pracę.");
                        Environment.Exit(0);
                        break;
                }
                
                // Program poczeka na wciśnięcie klawisza Enter zanim powróci do menu
                Console.Write("\nNaciśnij <Enter>, żeby wrócić do menu głównego.");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key.Equals(ConsoleKey.Enter)) Console.Clear();
            }
        }

        public static void Main(string[] args)
        {
            Startup();
        }
    }
}
