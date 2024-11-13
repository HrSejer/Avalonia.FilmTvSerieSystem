using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Models
{
    public class Recommendation
    {
        public int RecommendationID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public float RecommendationScore { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
