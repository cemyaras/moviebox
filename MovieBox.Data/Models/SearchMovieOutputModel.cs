using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieBox.Data.Models
{
    public class SearchMovieOutputModel
    {
        public SearchMovieOutputModel()
        {
            Movies = new List<Movie>();
        }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("movies")]
        public List<Movie> Movies { get; set; }

        public class Movie
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("year")]
            public int Year { get; set; }

            [JsonProperty("posters")]
            public Poster Posters { get; set; }

            public class Poster
            {
                [JsonProperty("profile")]
                public string Profile { get; set; }
            }
        }
    }
}
