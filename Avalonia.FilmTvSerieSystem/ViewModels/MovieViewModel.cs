using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TMDbLib.Objects.Movies;

namespace Avalonia.FilmTvSerieSystem.ViewModels
{
    public class MovieViewModel
    {
        private readonly TMDbService _tmdbService;

        public MovieViewModel(TMDbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        public async Task<Movie> GetMovieDetails(int movieId)
        {
            return await _tmdbService.GetMovieDetailsAsync(movieId);
        }

    }
}
