using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;
using System;

namespace Avalonia.FilmTvSerieSystem
{
    public class TMDbService
    {
        private readonly TMDbClient _client;

        public TMDbService(string apiKey)
        {
            _client = new TMDbClient(apiKey);
        }

        public async Task<Movie> GetMovieDetailsAsync(int movieId)
        {
            return await _client.GetMovieAsync(movieId);
        }

        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            var popularMovies = await _client.GetMoviePopularListAsync();

            return popularMovies.Results.Select(movie => new Movie
            {
                Title = movie.Title,
                PosterPath = !string.IsNullOrEmpty(movie.PosterPath)
                             ? $"https://image.tmdb.org/t/p/w500{movie.PosterPath}"
                             : null 
            }).ToList();
        }


    }
}
