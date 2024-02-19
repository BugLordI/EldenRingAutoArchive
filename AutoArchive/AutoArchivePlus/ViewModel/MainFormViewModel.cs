using AutoArchive.Tools;
using AutoArchivePlus.Command;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    public class MainFormViewModel : BaseViewModel
    {
        private bool showProjectInfo;

        private bool showHomePage = true;

        private Project currentProject;

        private ObservableCollection<Object> backups;

        public MainFormViewModel()
        {
            RunningProjectsManager.OnRunningSubscribe(OnRunningProject);
            RunningProjectsManager.OnChangedSubscribe(OnChangedProject);
        }

        #region Propertites

        public bool ShowProjectInfo
        {
            get
            {
                return showProjectInfo;
            }
            set
            {
                showProjectInfo = value;
                showHomePage = !value;
                OnPropertyChanged("ShowHomePage");
                OnPropertyChanged();
            }
        }

        public bool ShowHomePage
        {
            get
            {
                return showHomePage;
            }
            set
            {
                showHomePage = value;
                showProjectInfo = !value;
                OnPropertyChanged();
            }
        }

        public Project CurrentProject
        {
            get => currentProject;
            set
            {
                currentProject = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Object> Backups
        {
            get => backups;
            set
            {
                backups = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand BackupCommand => new ControlCommand(obj =>
        {
            if (CurrentProject != null)
            {
                DateTime now = DateTime.Now;
                String dirName = FileUtil.SanitizePath(CurrentProject.Name);
                String desPath = Path.Combine(CurrentProject.BackupPath, dirName, now.ToString("yyyyMMddHHmmss"));
                Backup backup = new Backup()
                {
                    Id = Guid.NewGuid().ToString(),
                    Path = desPath,
                    Remark = obj as string,
                    ProjectId = CurrentProject.Id,
                    DateTimeStamp = DateUtil.toUnixTimestamp(now),
                };
                if (FileUtil.copyDirectory(CurrentProject.ArchivePath, desPath))
                {
                    using DBContext<Backup> dbContext = new DBContext<Backup>();
                    dbContext.Entity.Add(backup);
                    dbContext.SaveChanges();
                }
                readBackups(CurrentProject.Id);
            }
        });

        public ICommand RecoverCommand => new ControlCommand(obj =>
        {
            if (obj is Backup backup)
            {
                var result = MessageBox.Show(String.Format(LanguageManager.Instance["ArchiveRecoverTip"], backup.Remark),
                                  LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    FileUtil.copyDirectory(backup.Path, CurrentProject.ArchivePath);
                    App.GlobalMessage(LanguageManager.Instance["ArchiveRecoverSuccessTip"]);
                }
            }
        });

        public ICommand OpenBackupPathCommand => new ControlCommand(obj =>
        {
            if (obj is Backup backup)
            {
                OS.OpenAndSelect(backup.Path);
            }
        });

        public ICommand DeleteBackupCommand => new ControlCommand(obj =>
        {
            if (obj is Backup backup)
            {
                var result = MessageBox.Show(String.Format(LanguageManager.Instance["DeleteBackupTip"], backup.Remark),
                                 LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DirectoryInfo dir = new DirectoryInfo(backup.Path);
                    if (dir.Exists)
                    {
                        dir.Delete(true);
                    }
                    using DBContext<Backup> dBContext = new DBContext<Backup>();
                    dBContext.Entity.Remove(backup);
                    dBContext.SaveChanges();
                    App.GlobalMessage(LanguageManager.Instance["DeleteBackupSuccessTip"]);
                    readBackups(CurrentProject.Id);
                }
            }
        });

        #endregion

        #region private Methods

        private void OnRunningProject(Project project)
        {
            ShowProjectInfo = true;
            CurrentProject = project;
            readBackups(project.Id);
        }

        private void OnChangedProject(Project project)
        {
            ShowProjectInfo = project.Name != LanguageManager.Instance["Home"];
            CurrentProject = project;
            readBackups(project.Id);
        }

        private void readBackups(string id)
        {
            if (id != Constant.HOME_PAGE_ID)
            {
                using DBContext<Project> dBContext = new DBContext<Project>();
                var project = dBContext.Entity.Include(e => e.Backups).Where(e => e.Id == id).FirstOrDefault();
                Backups = new ObservableCollection<Object>(project.Backups.OrderBy(e=>e.DateTimeStamp).Reverse());
            }
            else
            {
                Backups = null;
            }
        }

        #endregion
    }
}
