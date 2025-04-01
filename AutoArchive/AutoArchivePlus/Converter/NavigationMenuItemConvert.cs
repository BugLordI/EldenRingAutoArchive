/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AutoArchivePlus.Converter
{
    public class NavigationMenuItemConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool v)
            {
                if (targetType == typeof(Thickness))
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
                else if (targetType == typeof(Color))
                {
                    if (v)
                    {
                        return Color.FromRgb(234, 234, 234);
                    }
                    else
                    {
                        return Color.FromArgb(0, 255, 255, 255);
                    }
                }
                else if (targetType == typeof(Brush))
                {
                    if (v)
                    {
                        return new SolidColorBrush(Color.FromRgb(64, 158, 255));
                    }
                    else
                    {
                        return Brushes.Black;
                    }
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
