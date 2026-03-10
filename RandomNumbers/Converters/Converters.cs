using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace RandomNumbers.Converters
{
    // tekst szary jeśli nieobecny
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPresent = (bool)value;
            return isPresent ? Colors.Black : Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }

    // tło zielone jeśli szczęśliwy numer
    public class LuckyNumberColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hasLucky = (bool)value;
            return hasLucky ? Colors.LightGreen : Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
}
