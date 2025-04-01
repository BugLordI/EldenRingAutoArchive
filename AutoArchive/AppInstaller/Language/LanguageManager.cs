/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace AppInstaller.Language
{
    public class LanguageManager : INotifyPropertyChanged
    {
        private readonly ResourceManager _resourceManager;

        private static readonly Lazy<LanguageManager> _lazy = new Lazy<LanguageManager>(() => new LanguageManager());

        public static LanguageManager Instance => _lazy.Value;

        public event PropertyChangedEventHandler? PropertyChanged;

        public LanguageManager()
        {
            _resourceManager = new ResourceManager("AppInstaller.Resources.Lang", typeof(LanguageManager).Assembly);
        }

        /// <summary>
        /// getStrByCode
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string this[string name]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(name);
                var str = _resourceManager.GetString(name);
                return str ?? name;
            }
        }

        public void ChangeLanguage(CultureInfo cultureInfo)
        {
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("item[]"));
        }
    }
}