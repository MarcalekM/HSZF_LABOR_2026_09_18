using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HSZF_LABOR_2026_09_18
{
    internal class MovieManager
    {
        public event EventHandler<string> Event;

        private List<Movie> movies;
        private readonly string filePath = "movies.json";
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = false
        };

        public MovieManager()
        {
            LoadMovies();
        }

        private void LoadMovies()
        {
            if (File.Exists(filePath))
            {
                movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(filePath), options);
            }

            if (movies == null)
            {
                movies = new List<Movie>();
            }
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void AddMovie(string title, int minutes, DateTime? releaseDate)
        {
            Movie movie = new Movie(title, minutes, releaseDate);
            AddMovie(movie);
        }

        public void SaveMovies()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(movies, options));
            Event?.Invoke(this, "Load OK");
        }

        public void ListMovies()
        {
            string output = "Movies:\n";
            foreach (Movie movie in movies)
            {
                output += $"{movie.ToString()}\n";
            }
            Console.WriteLine(output);
        }

        public bool IsAnyMovieLongerThan(int minutes)
        {
            return movies.Any(m => m.Minutes > minutes);
        }

        public Movie LongerThan(int minutes)
        {
            return movies.FirstOrDefault(m => m.Minutes > minutes);
        }

        public string TitleLongerThan(int minutes)
        {
            var temp = movies.Select(x => new { x.Title, x.Minutes });
            return temp.FirstOrDefault(m => m.Minutes > minutes).Title;
        }
    }
}
