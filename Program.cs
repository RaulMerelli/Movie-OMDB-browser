using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Movie_omdb
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Omdb_main());
        }
    }

    public class Search
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class SearchResult
    {
        public List<Search> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; } //OK
        public string Year { get; set; } //OK
        public string Rated { get; set; } //OK
        public string Released { get; set; } //OK
        public string Runtime { get; set; } //OK
        public string Genre { get; set; } //OK
        public string Director { get; set; } //OK
        public string Writer { get; set; } //OK
        public string Actors { get; set; } //OK
        public string Plot { get; set; } //OK
        public string Language { get; set; } //OK
        public string Country { get; set; } //OK
        public string Awards { get; set; } //OK
        public string Poster { get; set; } //OK
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; } //OK
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; } //OK
        public string Type { get; set; } //OK
        public string DVD { get; set; } //OK
        public string BoxOffice { get; set; } //OK
        public string Production { get; set; } //OK
        public string Website { get; set; }
        public string Response { get; set; } //OK
    }
}