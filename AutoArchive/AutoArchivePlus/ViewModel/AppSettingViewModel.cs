using AutoArchivePlus.Command;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using AutoArchivePlus.WindowTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    public class AppSettingViewModel : BaseViewModel
    {

        private AppSetting appSetting;

        private bool isEnable;

        public AppSettingViewModel()
        {
            AppSetting = App.AppSetting.DeepCopyByBinary();
            AppSetting.PropertyChanged += AppSetting_PropertyChanged;
        }

        private void AppSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsEnable = !AppSetting.Equals(App.AppSetting);
        }

        public AppSetting AppSetting
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
            if (config == null)
            {
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
       
    }
}
