using AutoArchivePlus.Language;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AutoArchivePlus.Converter
{
    public class ShowProjectInfoConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool v)
            {
                if (targetType == typeof(Visibility))
                {
                    return v ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
