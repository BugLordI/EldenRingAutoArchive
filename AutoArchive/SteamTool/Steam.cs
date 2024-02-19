using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            List<AppConfiguration> appSaveInfos = readJson("GamesSaveDirectory.json", Encoding.UTF8);
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
                            SteamAppInfo steamAppInfo = new SteamAppInfo()
                            {
                                Appid = dic["appid"] as String,
                                Name = dic["name"] as String,
                                Installdir = steamPath + STEAM_APPS_INSTALL_PATH + installDir,
                                ExecutablePath = steamPath + STEAM_APPS_INSTALL_PATH + installDir,
                            };
                            infoFix(appSaveInfos.FirstOrDefault(e => e.AppId == steamAppInfo.Appid), ref steamAppInfo);
                            steamAppInfos.Add(steamAppInfo);

                        }
                        catch { }
                    }
                }
            }
            return steamAppInfos;
        }

        public static void SaveGameInfos(String content)
        {
            using (StreamWriter writer = new StreamWriter("GamesSaveDirectory.json",false))
            {
                writer.Write(content);
            }
        }

        private static void infoFix(AppConfiguration appSaveInfo, ref SteamAppInfo steamAppInfo)
        {
            if (appSaveInfo != null)
            {
                String specialFolder = appSaveInfo.SavedPath;
                String savedPath = appSaveInfo.SavedPath;
                if (savedPath != null)
                {
                    if (savedPath.StartsWith("%USERPROFILE%"))
                    {
                        specialFolder = specialFolder.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                    }
                    else if (savedPath.StartsWith("%CommonApplicationData%"))
                    {
                        specialFolder = specialFolder.Replace("%CommonApplicationData%", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
                    }
                    else if (savedPath.StartsWith("%MyDocuments%"))
                    {
                        specialFolder = specialFolder.Replace("%MyDocuments%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                    }
                }
                //TODO others folder
                steamAppInfo.ArchivePath = specialFolder;
                steamAppInfo.ExecutablePath += appSaveInfo.Executable;
            }
        }

        private static List<AppConfiguration> readJson(String jsonFile, Encoding encoding)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonFile, encoding);
                List<AppConfiguration> list = JsonConvert.DeserializeObject<List<AppConfiguration>>(jsonContent);
                return list;
            }
            catch
            {
                return new List<AppConfiguration>();
            }
        }
    }
}
