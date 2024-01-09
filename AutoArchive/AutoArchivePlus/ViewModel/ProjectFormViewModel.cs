using AutoArchive.DataBase;
using AutoArchivePlus.Command;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;

namespace AutoArchivePlus.ViewModel
{
    internal class ProjectFormViewModel : INotifyPropertyChanged
    {
        public event Action CloseRequest;

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

        public ICommand SaveProject => new ControlCommand(obj =>
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
            CloseRequest?.Invoke();
        });

        #endregion

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
