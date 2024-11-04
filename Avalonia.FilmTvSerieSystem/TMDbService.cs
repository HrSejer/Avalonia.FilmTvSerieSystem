using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using System.Threading.Tasks;

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

    }
}
