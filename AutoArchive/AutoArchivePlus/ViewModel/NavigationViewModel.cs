using AutoArchivePlus.Language;
using AutoArchivePlus.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
