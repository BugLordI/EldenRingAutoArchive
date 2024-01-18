using AutoArchivePlus.Model;
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
            projects = new ObservableCollection<Project>();
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
            Projects.Add(project);
        }
    }
}
