using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AutoArchivePlus.WindowTools
{
    public class BorderShowConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool v && targetType == typeof(Thickness))
            {
                if (v)
                {
                    return new Thickness(3, 0, 0, 0);
                }
                else
                {
                    return new Thickness(0, 0, 0, 0);
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
