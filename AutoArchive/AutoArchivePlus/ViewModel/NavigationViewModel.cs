using AutoArchivePlus.Command;
using AutoArchivePlus.Component;
using AutoArchivePlus.Language;
using AutoArchivePlus.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AutoArchivePlus.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Project> projects;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NavigationViewModel()
        {
            projects = new ObservableCollection<Project>
            {
                new Project
                {
                    Name = LanguageManager.Instance["Home"],
                    ImageLocation="pack://application:,,,/Resources/img/home.png",
                    IsSelect = true,
                    Id="1"
                }
            };
            RunningProjectsManager.OnRunningSubscribe(OnRunningProject);
        }

        #region Propertites

        public ObservableCollection<Project> Projects
        {
            get => projects;
            set
            {
                projects = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ItemClicked => new ControlCommand(obj =>
        {
            if (obj is Project project)
            {
                foreach (var pro in Projects)
                {
                    if (pro.Id == project.Id)
                    {
                        pro.IsSelect = true;
                        RunningProjectsManager.ChangeProject(pro);
                    }
                    else
                    {
                        pro.IsSelect = false;
                    }
                }
            }
        });

        public ICommand ClosePeoject => new ControlCommand(obj =>
        {
            if (obj is Project project)
            {
                Projects.Remove(project);
                RunningProjectsManager.Remove(project);
                for (int i = Projects.Count - 1; i >= 0; i--)
                {
                    if (i == Projects.Count - 1)
                    {
                        Projects[i].IsSelect = true;
                        RunningProjectsManager.ChangeProject(Projects[i]);
                    }
                    else
                    {
                        Projects[i].IsSelect = false;
                    }
                }
            }
        });

        #endregion

        private void OnRunningProject(Project project)
        {
            project.IsSelect = true;
            foreach (var pro in Projects)
            {
                pro.IsSelect = false;
            }
            Projects.Add(project);
        }
    }
}
