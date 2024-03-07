using Microsoft.Win32;
using Newtonsoft.Json;
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
        public const String STEAM_ACTIVE_PROCESS_PATH = @"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam\ActiveProcess";
        public const String STEAM_PATH_KEY = "SteamPath";
        public const String STEAM_ACTIVE_USER_KEY = "ActiveUser";
        public const String STEAM_APPS_INSTALL_PATH = @"\common\";
        public const String STEAM_APPS = @"\steamapps\";
        public const String ACF_FILE = "*.acf";
        public const String LIBRARY_FOLDERS_VDF_FILE = "libraryfolders.vdf";
        public static List<String> EXCLUDE = new List<String>() { "Steamworks Common Redistributables" };
        public static int steamUserId;
        public static String steamPath;

        public static List<SteamAppInfo> GetInstalledApps()
        {
            List<AppConfiguration> appSaveInfos = readJson("GamesSaveDirectory.json", Encoding.UTF8);
            List<SteamAppInfo> steamAppInfos = new List<SteamAppInfo>();
            steamPath = GetSteamPath();
            steamUserId = GetSteamActiveUserId();
            if (!String.IsNullOrEmpty(steamPath))
            {
                List<LibraryFolder> Installfolders = GetAppInstalledPath();
                foreach (LibraryFolder folder in Installfolders)
                {
                    String appPath = folder.Path + STEAM_APPS;
                    if (Directory.Exists(appPath))
                    {
                        var fileList = Directory.EnumerateFiles(appPath, ACF_FILE, SearchOption.TopDirectoryOnly);
                        foreach (var file in fileList)
                        {
                            var dic = SteamFilePaser.parseACF(file);
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
                                    Installdir = appPath + STEAM_APPS_INSTALL_PATH + installDir,
                                    ExecutablePath = appPath + STEAM_APPS_INSTALL_PATH + installDir,
                                };
                                infoFix(appSaveInfos.FirstOrDefault(e => e.AppId == steamAppInfo.Appid), ref steamAppInfo);
                                steamAppInfos.Add(steamAppInfo);

                            }
                            catch { }
                        }
                    }
                }
            }
            return steamAppInfos;
        }

        public static void SaveGameInfos(String content)
        {
            using (StreamWriter writer = new StreamWriter("GamesSaveDirectory.json", false))
            {
                writer.Write(content);
            }
        }
        private static String GetSteamPath()
        {
            return (String)Registry.GetValue(STEAM_REGISTRY_KEY_PATH, STEAM_PATH_KEY, "");
        }

        private static int GetSteamActiveUserId()
        {
            return (int)Registry.GetValue(STEAM_ACTIVE_PROCESS_PATH, STEAM_ACTIVE_USER_KEY, "");
        }

        private static List<LibraryFolder> GetAppInstalledPath()
        {
            String appPath = steamPath + STEAM_APPS;
            if (File.Exists(appPath + LIBRARY_FOLDERS_VDF_FILE))
            {
                return SteamFilePaser.parseVDF(appPath + LIBRARY_FOLDERS_VDF_FILE);
            }
            return null;
        }

        private static void infoFix(AppConfiguration appSaveInfo, ref SteamAppInfo steamAppInfo)
        {
            if (appSaveInfo != null)
            {
                String savedPath = appSaveInfo.SavedPath;
                if (savedPath != null)
                {
                    if (savedPath.StartsWith("%USERPROFILE%"))
                    {
                        savedPath = savedPath.Replace("%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                    }
                    else if (savedPath.StartsWith("%CommonApplicationData%"))
                    {
                        savedPath = savedPath.Replace("%CommonApplicationData%", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
                    }
                    else if (savedPath.StartsWith("%MyDocuments%"))
                    {
                        savedPath = savedPath.Replace("%MyDocuments%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                    }
                    else if (savedPath.StartsWith("%STEAMINSTALL%"))
                    {
                        savedPath = savedPath.Replace("%STEAMINSTALL%",steamPath);
                    }
                    // replace userId
                    if (steamUserId != 0)
                    {
                        if (savedPath.Contains("%Steam3AccountID%"))
                        {
                            savedPath = savedPath.Replace("%Steam3AccountID%", steamUserId.ToString());
                        }
                    }
                }
                steamAppInfo.ArchivePath = savedPath;
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
