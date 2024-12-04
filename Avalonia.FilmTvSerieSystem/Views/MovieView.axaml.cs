using Avalonia;
using Avalonia.Controls;
using Avalonia.FilmTvSerieSystem.ViewModels;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem.Views
{
    public partial class MovieView : UserControl
    {
        private readonly MovieViewModel _movieViewModel;

        // Constructor that receives the TMDbService instance
        public MovieView(TMDbService tmdbService)
        {
            InitializeComponent();
            _movieViewModel = new MovieViewModel(tmdbService);  // Pass the service to ViewModel
            DataContext = _movieViewModel;  // Set DataContext
        }

        // Constructor that receives the ViewModel directly
        public MovieView(MovieViewModel movieViewModel)
        {
            InitializeComponent();
            DataContext = movieViewModel;  // Set DataContext
        }
    }
}


