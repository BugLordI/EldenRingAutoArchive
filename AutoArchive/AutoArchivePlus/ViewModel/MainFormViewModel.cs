using AutoArchive.Tools;
using AutoArchivePlus.Command;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            DateTime now = DateTime.Now;
            Backup backup = new Backup()
            {
                Id = Guid.NewGuid().ToString(),
                Path = CurrentProject.BackupPath,
                Remark = obj as string,
                ProjectId = CurrentProject.Id,
                DateTimeStamp = DateUtil.toUnixTimestamp(now),
            };
            using DBContext<Backup> dbContext = new DBContext<Backup>();
            dbContext.Entity.Add(backup);
            dbContext.SaveChanges();
            readBackups(CurrentProject.Id);
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
                Backups = new ObservableCollection<Object>(project.Backups);
            }
            else
            {
                Backups = null;
            }
        }

        #endregion
    }
}
