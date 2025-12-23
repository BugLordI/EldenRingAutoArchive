/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchiveNext.Services;
using AutoArchiveNext.Views.Windows;
using System.Windows.Threading;

namespace AutoArchiveNext
{
    public class App : Application
    {
        private const String PRODUCT_NAME = "AUTO_ARCHIVE_NEXT";

        [STAThread]
        static void Main(string[] args)
        {
            SetLanguage(args);
            Mutex mutex = new Mutex(true, PRODUCT_NAME, out bool ret);
            if (ret)
            {
                Application app = new Application();
                app.DispatcherUnhandledException += App_DispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += App_DispatcherUnhandledException;
                var mainWindow = new MainWindow();
                app.Run(mainWindow);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(LocalizationService.Instance.GetString("LaunchFailed"), LocalizationService.Instance.GetString("Tip"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void App_DispatcherUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            MessageBox.Show(exception?.Message, LocalizationService.Instance.GetString("UnexpectedErrorTip"));
        }

        private static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message, LocalizationService.Instance.GetString("UnexpectedErrorTip"));
        }


        static void SetLanguage(string[] args)
        {
            var local = "--local:";
            foreach (var item in args)
            {
                if (item.Contains(local))
                {
                    var lan = item[local.Length..];
                    LocalizationService.Instance.ChangeLanguage(lan);
                    break;
                }
            }
        }
    }
}
