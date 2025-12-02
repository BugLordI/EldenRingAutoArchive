/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.Tools;
using AutoArchivePlus.Command;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using AutoArchivePlus.WindowTools;
using AutoUpdaterDotNET;
using KeyboardTool;
using KeyboardTool.Enums;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    public class AppSettingViewModel : BaseViewModel
    {

        private AppConfig appSetting;

        private bool isEnable;

        private String hookId;

        public AppSettingViewModel()
        {
            AppSetting = App.AppSetting.DeepCopyByBinary();
            if (Enum.TryParse<KeysEnum>(AppSetting.QuickBackupKeyCode.ToString(), out KeysEnum res))
            {
                AppSetting.QuickBackupKeyString = res.ToString();
            }
            if (Enum.TryParse<ModifierKeysEnum>(AppSetting.QuickBackupModifierKeyCode.ToString(), out ModifierKeysEnum mk)
                && mk != ModifierKeysEnum.NONE)
            {
                AppSetting.QuickBackupKeyString = mk.ToString() + "+" + AppSetting.QuickBackupKeyString;
            }
            AppSetting.PropertyChanged += AppSetting_PropertyChanged;
        }

        private void AppSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsEnable = !AppSetting.Equals(App.AppSetting);
        }

        public AppConfig AppSetting
        {
            get
            {
                return appSetting;
            }
            set
            {
                appSetting = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            private set
            {
                isEnable = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveSettings => new ControlCommand(obj =>
        {
            using DBContext<Config> dBContext = new DBContext<Config>();
            Config config = dBContext.Entity.Where(e => e.Type == Constant.APP_CONFIG_TYPE).FirstOrDefault();
            if (String.IsNullOrEmpty(AppSetting.QuickBackupKeyString))
            {
                AppSetting.EnableQuickBackup = false;
                AppSetting.QuickBackupKeyCode = (int)KeysEnum.NONE;
                AppSetting.QuickBackupKeyString = null;
            }
            if (config == null)
            {
                AppSetting.EnableQuickBackup = true;
                AppSetting.QuickBackupKeyCode = (int)KeysEnum.F12;
                AppSetting.QuickBackupKeyString = KeysEnum.F12.ToString();
                config = new Config()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Constant.APP_CONFIG_TYPE,
                    Content = JsonConvert.SerializeObject(AppSetting)
                };
                dBContext.Entity.Add(config);
            }
            else
            {
                config.Content = JsonConvert.SerializeObject(AppSetting);
            }
            dBContext.SaveChanges();
            Panel panel = obj as Panel;
            panel.ShowSuccessMessage(LanguageManager.Instance["DataSavedSuccess"]);
            var result = MessageBox.Show(LanguageManager.Instance["SettingRestartTip"], 
                LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                Application.Current.Shutdown();
            }
        });

        public ICommand VersionClicked => new ControlCommand(_ =>
        {
            String url = App.ConfigReader["UpdateUrl"];
            if (url != null)
            {
                try
                {
                    AutoUpdater.RunUpdateAsAdmin = false;
                    AutoUpdater.OpenDownloadPage = false;
                    AutoUpdater.ShowSkipButton = true;
                    AutoUpdater.ShowRemindLaterButton = true;
                    AutoUpdater.LetUserSelectRemindLater = true;
                    AutoUpdater.Synchronous = true; // 同步模式，等待更新检查完成
                    AutoUpdater.UpdateMode = Mode.ForcedDownload; // 强制下载模式
                    AutoUpdater.CheckForUpdateEvent += (args) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (args.Error != null)
                            {
                                MessageBox.Show(
                                    $"{args.Error.Message}",
                                    LanguageManager.Instance["UnexpectedErrorTip"],
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error
                                );
                                return;
                            }

                            if (args.IsUpdateAvailable)
                            {
                                // 有更新可用
                                AutoUpdater.ShowUpdateForm(args);
                            }
                            else
                            {
                                // 无更新
                                MessageBox.Show(
                                    LanguageManager.Instance["NoUpdatesAvailable"],
                                    LanguageManager.Instance["UpdateCheck"],
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information
                                );
                            }
                        });
                    };
                    AutoUpdater.Start(url);
                }
                catch
                {
                    MessageBox.Show(
                                   LanguageManager.Instance["UpdateCheckFail"],
                                   LanguageManager.Instance["UpdateCheck"],
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information
                               );
                    // 出错时回退到打开版本列表 URL
                    string fallbackUrl = App.ConfigReader["AppVersionListUrl"];
                    if (!string.IsNullOrEmpty(fallbackUrl))
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = fallbackUrl,
                                UseShellExecute = true
                            });
                        }
                        catch { }
                    }
                }
            }
        });

        public ICommand SetShortcutKey => new ControlCommand(o =>
        {
            hookId ??= KeyboardFactory.OnKeyPressed(o =>
                {
                    KeysEvent keysEvent = o as KeysEvent;
                    if (keysEvent.KeysAction == KeysActionEnum.KEYDOWN
                    || (keysEvent.KeysAction == KeysActionEnum.WM_SYSKEYDOWN))
                    {
                        AppSetting.QuickBackupKeyString = keysEvent.Key.ToString();
                        AppSetting.QuickBackupKeyCode = (int)keysEvent.Key;
                        if (keysEvent.ModifierKey != ModifierKeysEnum.NONE)
                        {
                            AppSetting.QuickBackupKeyString = $"{keysEvent.ModifierKey}+{keysEvent.Key}";
                        }
                        AppSetting.QuickBackupModifierKeyCode = (int)keysEvent.ModifierKey;
                    }
                });
        });

        public ICommand RemoveShortcutKey => new ControlCommand(_ =>
        {
            KeyboardFactory.UnRegisterKey(hookId);
            hookId = null;
        });

    }
}
