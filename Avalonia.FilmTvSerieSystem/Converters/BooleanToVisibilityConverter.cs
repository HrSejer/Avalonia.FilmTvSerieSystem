using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Avalonia.FilmTvSerieSystem.Converters
{
    public class BooleanToIsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b ? true : false; // Adjust this logic as necessary
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
