using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace AutoArchivePlus
{
    public class App : Application
    {
        const String PRODUCT_NAME = "AUTO_ARCHIVE";

        [STAThread]
        static void Main(string[] args)
        {
            setLanguage(args);
            Boolean ret;
            Mutex mutex = new Mutex(true, PRODUCT_NAME, out ret);
            if (ret)
            {
                Application app = new Application();
                MainForm mainForm = new MainForm();
                app.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(LanguageManager.Instance["LaunchFailed"], LanguageManager.Instance["Tip"], MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        static void setLanguage(string[] args)
        {
            var local = "--local:";
            foreach (var item in args)
            {
                if (item.Contains(local)) {
                    var lan = item.Substring(local.Length);
                    LanguageManager.Instance.ChangeLanguage(new CultureInfo(lan));
                    break;
                }
            }
        }
    }
}
