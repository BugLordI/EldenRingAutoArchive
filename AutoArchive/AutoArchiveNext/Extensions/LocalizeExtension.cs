/*
 * Copyright (c) 2023-2027 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchiveNext.Services;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace AutoArchiveNext.Extensions
{
    /// <summary>
    /// Provides a markup extension for retrieving localized strings in XAML based on a specified resource key.
    /// </summary>
    /// <remarks>Use this extension in XAML to bind UI elements to localized resources at runtime. The
    /// localized value will automatically update when the application's culture changes. This extension relies on the
    /// LocalizationService to provide localized strings.</remarks>
    /// <param name="key">The resource key used to look up the localized string.</param>
    internal class LocalizeExtension(string key) : MarkupExtension
    {
        public string Key { get; set; } = key;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // 创建多值绑定，监听 LocalizationService 实例的变化
            var multiBinding = new MultiBinding
            {
                Converter = new LocalizationMultiConverter(Key)
            };

            // 绑定到 LocalizationService 实例
            multiBinding.Bindings.Add(new Binding()
            {
                Source = LocalizationService.Instance,
                Mode = BindingMode.OneWay
            });

            // 绑定到 CurrentCulture 属性来触发更新
            multiBinding.Bindings.Add(new Binding("CurrentCulture")
            {
                Source = LocalizationService.Instance,
                Mode = BindingMode.OneWay
            });

            return multiBinding.ProvideValue(serviceProvider);
        }

        private class LocalizationMultiConverter : IMultiValueConverter
        {
            private readonly string _key;

            public LocalizationMultiConverter(string key)
            {
                _key = key;
            }

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values.Length > 0 && values[0] is LocalizationService service)
                {
                    return service.GetString(_key);
                }
                return $"[{_key}]";
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
