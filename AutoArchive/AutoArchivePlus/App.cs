using AutoArchive.DataBase;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace AutoArchivePlus
{
    public class App : Application
    {
        const String PRODUCT_NAME = "AUTO_ARCHIVE";

        private static MainForm mainForm = new MainForm();

        [STAThread]
        static void Main(string[] args)
        {
            dbInit();
            setLanguage(args);
            Boolean ret;
            Mutex mutex = new Mutex(true, PRODUCT_NAME, out ret);
            if (ret)
            {
                Application app = new Application();
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

        public static void GlobalMessage(String msg)
        {
            mainForm?.Message(msg);
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

        static void dbInit()
        {
            using BaseContext<Project> baseContext = new DBContext<Project>();
            var data = baseContext.Entity.ToList()[0];
            Trace.WriteLine(data);
        }
    }
}
