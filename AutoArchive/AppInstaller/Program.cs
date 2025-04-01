/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AppInstaller.Forms;
using AppInstaller.Language;

namespace AppInstaller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            SetLanguage(args);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Welcome());
        }

        static void SetLanguage(String[] args)
        {
            foreach (var item in args)
            {
                if (item.Contains("Lang:"))
                {
                    var lang = item.Split(':')[1];
                    LanguageManager.Instance.ChangeLanguage(new System.Globalization.CultureInfo(lang));
                    break;
                }
            }
        }
    }
}