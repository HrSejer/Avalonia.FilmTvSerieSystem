using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public bool IsTvSeries { get; set; }
        public float AverageRating { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}
