using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TMDbLib.Objects.Movies;
using Avalonia.FilmTvSerieSystem.Views;
using Avalonia.Media.Imaging;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using System.Xml.XPath;
using Avalonia.FilmTvSerieSystem.Models;

namespace Avalonia.FilmTvSerieSystem.ViewModels
{
    public class MovieViewModel : ObservableObject
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly TMDbService _tmdbService;
        public ObservableCollection<TMDbLib.Objects.Movies.Movie> PopularMovies { get; }
        public ICommand ShowMovieDetailsCommand { get; }
        public event Action<TMDbLib.Objects.Movies.Movie>? MovieSelected;
        private TMDbLib.Objects.Movies.Movie? _selectedMovie;
        public TMDbLib.Objects.Movies.Movie? SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }

        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value);
        }

        // Store the poster images as Bitmap for binding
        public ObservableCollection<Bitmap> MoviePosters { get; }

        public MovieViewModel(TMDbService tmdbService)
        {
            _tmdbService = tmdbService;
            PopularMovies = new ObservableCollection<TMDbLib.Objects.Movies.Movie>();
            MoviePosters = new ObservableCollection<Bitmap>();
            ShowMovieDetailsCommand = new RelayCommand<TMDbLib.Objects.Movies.Movie>(ShowMovieDetails);
            LoadPopularMovies();
        }

        private async void LoadPopularMovies()
        {
            try
            {
                Loading = true;

                // Get the movies from TMDb API
                var tmdbMovies = await _tmdbService.GetPopularMoviesAsync();

                PopularMovies.Clear();

                foreach (var tmdbMovie in tmdbMovies)
                {
                    var movie = new TMDbLib.Objects.Movies.Movie
                    {
                        Title = tmdbMovie.Title,
                        PosterPath = tmdbMovie.PosterPath,

                    };

                    PopularMovies.Add(movie);
                }
            }
            finally
            {
                Loading = false;
            }
        }
        private void ShowMovieDetails(TMDbLib.Objects.Movies.Movie selectedMovie)
        {
            if (selectedMovie != null)
            {
                _mainWindowViewModel.NavigateToDetails(selectedMovie);
            }
        }
    }
}
