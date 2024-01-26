using AutoArchivePlus.Command;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using AutoArchivePlus.WindowTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoArchivePlus.ViewModel
{
    public class AppSettingViewModel : BaseViewModel
    {

        private AppSetting appSetting;

        public AppSettingViewModel()
        {
            initSettings();
        }

        private void initSettings()
        {
            using DBContext<Config> dBContext = new DBContext<Config>();
            Config config = dBContext.Entity.Where(e => e.Type == Constant.APP_CONFIG_TYPE).FirstOrDefault();
            if (config == null)
            {
                AppSetting = new AppSetting();
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
                AppSetting = JsonConvert.DeserializeObject<AppSetting>(content);
            }
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
            Panel panel=obj as Panel;
            panel.ShowSuccessMessage("保存成功");
        });
    }
}
