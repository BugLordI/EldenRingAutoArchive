using AutoArchive.Tools;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AutoArchivePlus.Converter
{
    public class LongTimeDateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is long val)
            {
                return DateUtil.getDateTime(val).ToString("yyyy/MM/dd HH:mm:ss");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
