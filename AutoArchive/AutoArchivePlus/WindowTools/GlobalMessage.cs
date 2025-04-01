/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoArchivePlus.WindowTools
{
    public static class GlobalMessage
    {
        public static void ShowSuccessMessage(this Panel panel, String message)
        {
            Application.Current.Dispatcher?.Invoke(delegate
            {
                Growl growl = new Growl
                {
                    Height = panel.Height,
                    Width = 200,
                    Message = message,
                    Time = DateTime.Now,
                    Icon = panel.TryFindResource("SuccessGeometry") as Geometry,
                    IconBrush= panel.TryFindResource("SuccessBrush") as Brush,
                    //_showCloseButton = growlInfo.ShowCloseButton,
                    //ActionBeforeClose = growlInfo.ActionBeforeClose,
                    //_staysOpen = growlInfo.StaysOpen,
                    ShowDateTime = true,
                    //ConfirmStr = growlInfo.ConfirmStr,
                    //CancelStr = growlInfo.CancelStr,
                    Type = InfoType.Success,
                    //_waitTime = Math.Max(growlInfo.WaitTime, 2)
                };
                UnsafeOp(growl, "_showCloseButton", true);
                UnsafeOp(growl, "_waitTime", 3);
                panel.Children.Insert(0, growl);
            });
        }

        public static void ShowErrorMessage(this Panel panel, String message)
        {
            Application.Current.Dispatcher?.Invoke(delegate
            {
                Growl growl = new Growl
                {
                    Height = panel.Height,
                    Width = 200,
                    Message = message,
                    Time = DateTime.Now,
                    Icon = panel.TryFindResource("ErrorGeometry") as Geometry,
                    IconBrush = panel.TryFindResource("DangerBrush") as Brush,
                    ShowDateTime = true,
                    Type = InfoType.Success,
                };
                UnsafeOp(growl, "_showCloseButton", true);
                UnsafeOp(growl, "_waitTime", 3);
                UnsafeOp(growl, "_staysOpen", true);
                panel.Children.Insert(0, growl);
            });
        }

        private static void UnsafeOp(Growl growl, String fieldName, Object value)
        {
            FieldInfo field = growl.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(growl, value);
        }
    }
}
