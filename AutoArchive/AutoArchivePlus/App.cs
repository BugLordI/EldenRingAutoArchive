using AutoArchivePlus.Common;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using Newtonsoft.Json;
using SteamTool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace AutoArchivePlus
{
    public class App : Application
    {
        private const String PRODUCT_NAME = "AUTO_ARCHIVE";

        private static String iconPath = "Icons";

        private static MainForm mainForm;

        private static AppSetting appSetting = new AppSetting();

        public static List<SteamAppInfo> InstalledApps { get; private set; } = new List<SteamAppInfo>();

        public static string ICON_PATH { get => iconPath; }

        public static AppSetting AppSetting { get => appSetting;}


        [STAThread]
        static void Main(string[] args)
        {
            iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath);
            if (!Directory.Exists(iconPath))
            {
                Directory.CreateDirectory(iconPath);
            }
            loadInstalledApps();
            setLanguage(args);
            loadSetting();
            Boolean ret;
            Mutex mutex = new Mutex(true, PRODUCT_NAME, out ret);
            if (ret)
            {
                Application app = new Application();
                mainForm = new MainForm();
                app.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(LanguageManager.Instance["LaunchFailed"], LanguageManager.Instance["Tip"], MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static Window GetMainWindow()
        {
            return mainForm;
        }

        public static void GlobalMessage(String msg, MessageTypeEnum messageType = MessageTypeEnum.INFO)
        {
            mainForm?.Message(msg, messageType);
        }

        static void setLanguage(string[] args)
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

        static void loadSetting()
        {

            using DBContext<Config> dBContext = new DBContext<Config>();
            Config config = dBContext.Entity.Where(e => e.Type == Constant.APP_CONFIG_TYPE).FirstOrDefault();
            if (config == null)
            {
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
                appSetting = JsonConvert.DeserializeObject<AppSetting>(content);
            }
        }

        static void loadInstalledApps()
        {
            Thread thread = new Thread(() =>
            {
                InstalledApps = Steam.GetInstalledApps();
            });
            thread.Start();
        }
    }
}
