using AutoArchivePlus.Language;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AutoArchivePlus.Converter
{
    public class HomePageRunBtnConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool v)
            {
                if (!v)
                {
                    return LanguageManager.Instance["OpenSelected"];
                }
                else
                {
                    return LanguageManager.Instance["IsRunning"];
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
