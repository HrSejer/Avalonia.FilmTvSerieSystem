using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}
