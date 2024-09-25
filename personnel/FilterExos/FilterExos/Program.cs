using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FilterExos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] words = { "bonjoureee", "hello", "monde", "vert", "rouge", "bleu", "jaune", "coc", "coucoux" };

            ////////////////////////////////////////////////////////////// EXERCICE 1 //////////////////////////////////////////////////////////////
            Console.WriteLine("EXERCICE 1");

            words
                .Where(w => !w.Contains("x") && w.Length >= 4 && words.Average(wr => wr.Length) == w.Length)
                .ToList()
                .ForEach(w => Console.WriteLine(w));

            Console.WriteLine();


            ////////////////////////////////////////////////////////////// EXERCICE 1 BIS //////////////////////////////////////////////////////////////
            Console.WriteLine("EXERCICE 1 BIS");

            Dictionary<char, double> frequencesLettres = new Dictionary<char, double>()
            {
                {'a', 8.13},
                {'b', 0.93},
                {'c', 3.15},
                {'d', 3.55},
                {'e', 17.26},
                {'f', 1.07},
                {'g', 0.97},
                {'h', 0.74},
                {'i', 7.34},
                {'j', 0.31},
                {'k', 0.05},
                {'l', 5.69},
                {'m', 2.97},
                {'n', 7.10},
                {'o', 5.27},
                {'p', 2.88},
                {'q', 1.36},
                {'r', 6.65},
                {'s', 7.95},
                {'t', 7.07},
                {'u', 5.74},
                {'v', 1.32},
                {'w', 0.04},
                {'x', 0.45},
                {'y', 0.30},
                {'z', 0.12}
            };

            List<string> list = words 
                .Where(w => CalculateEpsilon(w) >= 0.5 && CalculateEpsilon(w) <= 0.95)
                .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Pas de réponse");
            }
            else
            {
                list.ForEach(w => Console.WriteLine(w));
            }

            double CalculateEpsilon(string word)
            {
                char[] wordCharArray = word.ToCharArray();

                return wordCharArray.Select(c => frequencesLettres[c] / 100).ToList().Sum();
            }


            ////////////////////////////////////////////////////////////// EXERCICE CINEMA //////////////////////////////////////////////////////////////


            List<Movie> frenchMovies = new List<Movie>() {
                new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
                new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
                new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
                new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
                new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
             };

            List<Movie> goodMovies = frenchMovies.Where(m => 
                m.Genre != "Comédie" && m.Genre != "Drame" && 
                m.Rating < 7 &&
                m.Year < 2000 &&
                !m.LanguageOptions.Contains("Français") &&  
                !m.StreamingPlatforms.Contains("Netflix")
            ).ToList();

            foreach (Movie movie in goodMovies)
            {
                Console.WriteLine(movie.Title);
            }

            Console.ReadLine();
        }
    }
}
