using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int RatingValue { get; set; }
        public DateTime RatingDate { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
