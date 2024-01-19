using AutoArchivePlus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutoArchivePlus.ViewModel
{
    public class MainFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool showProjectInfo;

        private bool showHomePage = true;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainFormViewModel()
        {
            RunningProjectsManager.OnRunningSubscribe(OnRunningProject);
        }

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

        private void OnRunningProject(Project project)
        {
            ShowProjectInfo = true;
        }
    }
}
