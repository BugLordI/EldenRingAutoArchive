using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SteamTool
{
    public class Steam
    {
        public const String STEAM_REGISTRY_KEY_PATH = @"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam";
        public const String STEAM_PATH_KEY = "SteamPath";
        public const String STEAM_APPS_INSTALL_PATH = @"\steamapps\common\";
        public const String STEAM_APPS = @"\steamapps\";
        public const String ACF_FILE = "*.acf";
        public const String VDF_FILE = "*.vdf";
        public const String LIBRARYFOLDERS_VDF= "libraryfolders.vdf";
        public static List<String> EXCLUDE = new List<String>() { "Steamworks Common Redistributables" };

        public static String GetSteamPath()
        {
            return (String)Registry.GetValue(STEAM_REGISTRY_KEY_PATH, STEAM_PATH_KEY, "");
        }

        public static List<SteamAppInfo> GetInstalledApps()
        {
            List<SteamAppInfo> steamAppInfos = new List<SteamAppInfo>();
            String steamPath = Steam.GetSteamPath();
            if (!String.IsNullOrEmpty(steamPath))
            {
                String appPath = steamPath + STEAM_APPS;
                if (Directory.Exists(appPath))
                {
                    var fileList = Directory.EnumerateFiles(appPath, ACF_FILE, SearchOption.TopDirectoryOnly);
                    // .Union(Directory.EnumerateFiles(appPath, VDF_FILE, SearchOption.TopDirectoryOnly));
                    foreach (var file in fileList)
                    {
                        var dic = VDFPaser.parseVdf(file);
                        try
                        {
                            if (EXCLUDE.Contains(dic["name"]))
                            {
                                continue;
                            }
                            String installDir = dic["installdir"] as String;
                            var a = installDir.Replace(" ", "");
                            steamAppInfos.Add(new SteamAppInfo()
                            {
                                Appid = dic["appid"] as String,
                                Name = dic["name"] as String,
                                Installdir = steamPath + STEAM_APPS_INSTALL_PATH + installDir,
                                ExecutablePath = steamPath + STEAM_APPS_INSTALL_PATH + installDir + "\\"
                                 + installDir.Replace(" ", "") + ".exe"
                            });
                        }
                        catch { }
                    }
                }
            }
            return steamAppInfos;
        }
    }
}
