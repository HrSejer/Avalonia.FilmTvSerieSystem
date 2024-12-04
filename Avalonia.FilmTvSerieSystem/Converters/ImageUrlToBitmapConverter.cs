using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Controls;
using System.IO;

namespace Avalonia.FilmTvSerieSystem.Converters
{
    public class ImageUrlToBitmapConverter : IValueConverter
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imageUrl && Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                try
                {
                    // Fetch and return the bitmap asynchronously
                    var task = Task.Run(async () => await LoadBitmapFromUrlAsync(imageUrl));
                    return task.Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load image: {ex.Message}");
                }
            }
            return null; // Return null if the URL is invalid
        }

        private async Task<Bitmap> LoadBitmapFromUrlAsync(string url)
        {
            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            return new Bitmap(stream);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}