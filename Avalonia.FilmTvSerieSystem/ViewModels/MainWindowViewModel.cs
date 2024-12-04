using Avalonia.FilmTvSerieSystem.Models;
using Avalonia.FilmTvSerieSystem.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TMDbLib.Objects.Movies;

namespace Avalonia.FilmTvSerieSystem.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        private readonly TMDbService _tmdbService;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCommand { get; }

        public MainWindowViewModel()
        {
            string apiKey = Program.Configuration["TMDb:ApiKey"];
            _tmdbService = new TMDbService(apiKey);

            var movieViewModel = new MovieViewModel(_tmdbService);
            movieViewModel.MovieSelected += OnMovieSelected;

            CurrentView = new MovieView(_tmdbService)
            {
                DataContext = movieViewModel
            };

            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object? viewName)
        {
            switch (viewName)
            {
                case "Home":
                    var movieViewModel = new MovieViewModel(_tmdbService);
                    movieViewModel.MovieSelected += OnMovieSelected;
                    var movieView = new MovieView(_tmdbService)
                    {
                        DataContext = movieViewModel
                    };
                    CurrentView = movieView; // Assign MovieView with its DataContext set
                    break;

                case "Watchlist":
                    CurrentView = new WatchlistView();
                    break;

                case "Search":
                    CurrentView = new SearchView();
                    break;

                case "Ratings":
                    CurrentView = new RatingsView();
                    break;

                default:
                    throw new ArgumentException("Unknown view");
            }
        }


        private void OnMovieSelected(TMDbLib.Objects.Movies.Movie selectedMovie)
        {
            CurrentView = new MovieDetailsView
            {
                DataContext = new MovieDetailsViewModel(selectedMovie)
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
