using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}
