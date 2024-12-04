using Avalonia.FilmTvSerieSystem.Models;
using Avalonia.Rendering;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.ViewModels
{
    public class MovieDetailsViewModel : ObservableObject
    {
        public TMDbLib.Objects.Movies.Movie SelectedMovie { get; }
        public string Title => SelectedMovie.Title;
        public string Overview => SelectedMovie.Overview;
        public string PosterPath => SelectedMovie.PosterPath;

        public MovieDetailsViewModel(TMDbLib.Objects.Movies.Movie selectedMovie)
        {
            SelectedMovie = selectedMovie;
        }
    }
}
