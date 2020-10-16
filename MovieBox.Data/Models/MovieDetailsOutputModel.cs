using Newtonsoft.Json;
using System;

namespace MovieBox.Data.Models
{
    public class MovieDetailsOutputModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("ratingSummary")]
        public RatingSummaries RatingSummary { get; set; }

        [JsonProperty("posters")]
        public Poster Posters { get; set; }

        public class Poster
        {
            [JsonProperty("profile")]
            public string Profile { get; set; }
        }

        public class RatingSummaries
        {
            [JsonProperty("topCritics")]
            public Critics TopCritics { get; set; }

            public class Critics
            {
                private double rating;

                [JsonProperty("averageRating")]
                public double AverageRating
                {
                    get
                    {
                        return Math.Round(rating, 2);
                    }
                    set { rating = value; }
                }
            }



        }
    }
}
