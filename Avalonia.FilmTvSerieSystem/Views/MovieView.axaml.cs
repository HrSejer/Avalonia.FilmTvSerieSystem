using Avalonia;
using Avalonia.Controls;
using Avalonia.FilmTvSerieSystem.ViewModels;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace Avalonia.FilmTvSerieSystem;

public partial class MovieView : UserControl
{
    private readonly MovieViewModel _movieViewModel;
    public MovieView()
    {
        InitializeComponent();
    }

    public MovieView(MovieViewModel movieViewModel)
    {
        _movieViewModel = movieViewModel;
    }

    public async Task LoadMovie(int movieId)
    {
        var movie = await _movieViewModel.GetMovieDetails(movieId);
    }
}