/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using SHDocVw;
using Shell32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Tools
{
    public class OS
    {
        [DllImport("shell32.dll", EntryPoint = "#261", CharSet = CharSet.Unicode)]
        public static extern void GetUserTilePath(string username,UInt32 whatever, StringBuilder picpath, int maxLength);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        public static string CreateUserTilePath()
        {   
            var sb = new StringBuilder(1000);
            GetUserTilePath(null, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static String GetCurrentUserPicturePath() {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp";
        }

        public static String GetCurrentUserName()
        {
            return Environment.UserName;
        }

        public static void OpenAndSelect(String path)
        {
            Shell shell = new Shell();
            foreach (var window in shell.Windows())
            {
                if (window is InternetExplorer ie && ie.FullName.ToLower().Contains("explorer.exe"))
                {
                    string currentUrl = ie.LocationURL;
                    if (string.IsNullOrEmpty(currentUrl))
                        continue;
                    string currentPath = Uri.UnescapeDataString(new Uri(currentUrl).LocalPath);
                    var a = Directory.GetParent(path).FullName;
                    if (currentPath == a)
                    {
                        IntPtr hWnd = (IntPtr)window.HWND;
                        ShowWindow(hWnd, 9);
                        SwitchToThisWindow(hWnd, true);
                        return;
                    }
                }
            }
            ProcessStartInfo psi = new()
            {
                FileName = "explorer",
                Arguments = @"/select," + path
            };
            Process proc = Process.Start(psi);
        }
    }
}
