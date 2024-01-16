using AutoArchive.DataBase;
using AutoArchivePlus.Command;
using AutoArchivePlus.Common;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutoArchivePlus.ViewModel
{
    internal class ProjectFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String gameName;

        private String gameInstallPath;

        private String gameArchivePath;

        private String gameBackupPath;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProjectFormViewModel()
        {
        }

        #region Commands

        public ICommand SaveProject => new ControlCommand(_ =>
        {
            if (dataCheck())
            {
                using BaseContext<Project> baseContext = new DBContext<Project>();
                Project project = new Project()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = gameName,
                    InstallPath = gameInstallPath,
                    ArchivePath = gameArchivePath,
                    BackupPath = gameBackupPath,
                };
                baseContext.Entity.Add(project);
                baseContext.SaveChanges();
                App.GlobalMessage(LanguageManager.Instance["DataSavedSuccess"]);
                ((Window)_).Close();
            }
        });

        #endregion

        private bool dataCheck()
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(gameName))
            {
                msg.Append(LanguageManager.Instance["ProjectNameCannotEmpty"]).Append("\n");
            }
            if (string.IsNullOrEmpty(gameInstallPath))
            {
                msg.Append(LanguageManager.Instance["ProjectInstallPathCannotEmpty"]).Append("\n");
            }
            if (string.IsNullOrEmpty(gameArchivePath))
            {
                msg.Append(LanguageManager.Instance["ChooseDataSourcePath"]).Append("\n");
            }
            if (String.IsNullOrEmpty(gameBackupPath))
            {
                msg.Append(LanguageManager.Instance["ChooseBackupSavePath"]).Append("\n");
            }
            if (msg.Length > 0)
            {
                App.GlobalMessage(msg.ToString(), MessageTypeEnum.ERROR);
            }
            return msg.Length == 0;
        }

        #region Propertites

        public String GameName
        {
            get
            {
                return gameName;
            }
            set
            {
                gameName = value;
                OnPropertyChanged();
            }
        }

        public string GameInstallPath
        {
            get => gameInstallPath;
            set
            {
                gameInstallPath = value; 
                OnPropertyChanged();
            }
        }

        public string GameArchivePath
        {
            get => gameArchivePath; 
            set
            {
                gameArchivePath = value; 
                OnPropertyChanged();
            }
        }

        public string GameBackupPath
        {
            get => gameBackupPath;
            set
            {
                gameBackupPath = value; 
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
