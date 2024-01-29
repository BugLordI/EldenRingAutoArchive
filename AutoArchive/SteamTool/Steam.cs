using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;

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

        public static String GetSteamPath()
        {
            return (String)Registry.GetValue(STEAM_REGISTRY_KEY_PATH, STEAM_PATH_KEY, "");
        }

        public static void GetInstalledApps()
        {
            String steamPath = Steam.GetSteamPath();
            if (!String.IsNullOrEmpty(steamPath))
            {
                String appPath = steamPath + STEAM_APPS;
                if(Directory.Exists(appPath))
                {
                    var fileList = Directory.EnumerateFiles(appPath, ACF_FILE, SearchOption.TopDirectoryOnly)
                        .Union(Directory.EnumerateFiles(appPath, VDF_FILE, SearchOption.TopDirectoryOnly));
                    foreach ( var file in fileList )
                    {

                    }
                }
            }
        }
    }
}
