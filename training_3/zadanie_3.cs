using System;
using System.Collections.Generic;
using System.IO;

namespace kolokwium_2_zad_3
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

        public static string NotEmptyString(this string instance)
        {
            if (instance == "")
            {
                Console.WriteLine("Lańcuch nie może być pusty.");
                Environment.Exit(0);
            }

            return instance;
        }
    }
    
    internal static class IntExtensions
    {
        public static int FitsReleaseYearRange(this int instance)
        {
            if (instance > 2300 || instance < 1900)
            {
               Console.WriteLine("Data wydania wychodzi poza zakres 1900 - 2300"); 
               Environment.Exit(0);
            }

            return instance;
        }
    }
    
    class Program
    {
        private class MusicAlbum
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public string MediaType { get; set; }
            public int ReleaseYear { get; set; }

            public MusicAlbum(string title, string artist, string mediaType, int releaseYear)
            {
                Title = title;
                Artist = artist;
                MediaType = mediaType;
                ReleaseYear = releaseYear;
            }
        }

        private static List<MusicAlbum> CreateAlbum()
        {
            Console.Write("Podaj liczbę płyt, którą chcesz dodać do pliku: ");
            int quantity = Console.ReadLine().ParseInt();

            List<MusicAlbum> albumList = new List<MusicAlbum>();
            
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine($"[{i}/{quantity}]");

                Console.Write("Podaj tytuł: ");
                string title = Console.ReadLine().NotEmptyString();
                
                Console.Write("Podaj wykonawcę: ");
                string artist = Console.ReadLine().NotEmptyString();
                
                Console.Write("Nośnik: ");
                string mediaType = Console.ReadLine().NotEmptyString();
                
                Console.Write("Podaj rok wydania: ");
                int releaseYear = Console.ReadLine().ParseInt().FitsReleaseYearRange();

                MusicAlbum album = new MusicAlbum(title, artist, mediaType, releaseYear);
                albumList.Add(album);
                
                Console.WriteLine();
            }

            return albumList;
        }

        private static void ReadAlbum(string catalogName)
        {
            try
            {
                Console.WriteLine($"Mój katalog {catalogName}.txt");
                
                string[] lines = File.ReadAllLines($@"C:\Users\PC\Desktop\{catalogName}.txt");
                
                Console.WriteLine("Tytuł, Wykonawca, Nośnik, Rok wydania");

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Podany plik nie istnieje.");
                Environment.Exit(0);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Podana ścieżka nie istnieje.");
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Nie masz praw do tego pliku.");
                Environment.Exit(0);
            }
            catch (IOException e)
            {
                Console.WriteLine("Błąd zapisu do pliku.");
                Environment.Exit(0);
            }
        }

        private static string WriteAlbum(List<MusicAlbum> catalog)
        {
            try
            {
                Console.Write("Podaj nazwę pliku katalogu: ");
                string catalogName = Console.ReadLine().NotEmptyString();

                while (File.Exists($@"C:\Users\PC\Desktop\{catalogName}.txt"))
                {
                    catalogName += "_1";
                }
                
                using (TextWriter tw = new StreamWriter($@"C:\Users\PC\Desktop\{catalogName}.txt"))
                {
                    catalog.ForEach(album =>
                        tw.WriteLine(
                            string.Format($"{album.Title}; {album.Artist}; {album.MediaType}; {album.ReleaseYear}")));
                }

                Console.WriteLine($"Katalog został zapisany pod nazwą {catalogName}.txt");

                Console.WriteLine();

                return catalogName;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Podana ścieżka nie istnieje.");
                return "";
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Nie masz praw do tego pliku.");
                return "";
            }
            catch (IOException e)
            {
                Console.WriteLine("Błąd zapisu do pliku.");
                return "";
            }
        }
        
        static void Main(string[] args)
        {
            List<MusicAlbum> catalog = CreateAlbum();
            string catalogName = WriteAlbum(catalog);
            
            if (catalogName.Length > 0) {
                ReadAlbum(catalogName);
            }
        }
    }
}
