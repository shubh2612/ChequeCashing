﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace ChequeCashing.Converters
{
    public class TextToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || string.IsNullOrWhiteSpace(value?.ToString()) ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
