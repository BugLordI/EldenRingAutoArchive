/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.Tools;
using AutoArchivePlus.Common;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using KeyboardTool.Enums;
using Newtonsoft.Json;
using SteamTool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace AutoArchivePlus
{
    public class App : Application
    {
        private const String PRODUCT_NAME = "AUTO_ARCHIVE";

        private static String iconPath = "Icons";

        private static MainForm mainForm;

        private static AppConfig appSetting = new();

        private static readonly JsonConfigReader configReader = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppConfig.json"));

        public static List<SteamAppInfo> InstalledApps { get; private set; } = new List<SteamAppInfo>();

        public static string ICON_PATH { get => iconPath; }

        public static AppConfig AppSetting { get => appSetting;}

        public static JsonConfigReader ConfigReader { get  => configReader; }

        [STAThread]
        static void Main(string[] args)
        {
            iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath);
            if (!Directory.Exists(iconPath))
            {
                Directory.CreateDirectory(iconPath);
            }
            LoadInstalledApps();
            SetLanguage(args);
            LoadSetting();
            Boolean ret;
            Mutex mutex = new Mutex(true, PRODUCT_NAME, out ret);
            if (ret)
            {
                Application app = new Application();
                app.DispatcherUnhandledException += App_DispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += App_DispatcherUnhandledException;
                mainForm = new MainForm();
                app.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(LanguageManager.Instance["LaunchFailed"], LanguageManager.Instance["Tip"], MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void App_DispatcherUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            MessageBox.Show(exception?.Message, LanguageManager.Instance["UnexpectedErrorTip"]);
        }

        private static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message, LanguageManager.Instance["UnexpectedErrorTip"]);
        }

        public static Window GetMainWindow()
        {
            return mainForm;
        }

        public static void GlobalMessage(String msg, MessageTypeEnum messageType = MessageTypeEnum.INFO)
        {
            mainForm?.Message(msg, messageType);
        }

        static void SetLanguage(string[] args)
        {
            var local = "--local:";
            foreach (var item in args)
            {
                if (item.Contains(local))
                {
                    var lan = item.Substring(local.Length);
                    LanguageManager.Instance.ChangeLanguage(new CultureInfo(lan));
                    break;
                }
            }
        }

        static void LoadSetting()
        {
            using DBContext<Config> dBContext = new();
            Config config = dBContext.Entity.Where(e => e.Type == Constant.APP_CONFIG_TYPE).FirstOrDefault();
            if (config == null)
            {
                appSetting.EnableQuickBackup = true;
                appSetting.QuickBackupKeyCode = (int)KeysEnum.F12;
                appSetting.QuickBackupKeyString=KeysEnum.F12.ToString();
                config = new Config()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Constant.APP_CONFIG_TYPE,
                    Content = JsonConvert.SerializeObject(AppSetting)
                };
                dBContext.Entity.Add(config);
                dBContext.SaveChanges();
            }
            else
            {
                String content = config.Content;
                appSetting = JsonConvert.DeserializeObject<AppConfig>(content);
            }
        }

        static void LoadInstalledApps()
        {
            Thread thread = new(() =>
            {
                InstalledApps = Steam.GetInstalledApps();
            });
            thread.Start();
        }
    }
}
