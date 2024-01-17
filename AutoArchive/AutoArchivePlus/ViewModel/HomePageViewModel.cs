using AutoArchive.DataBase;
using AutoArchivePlus.Command;
using AutoArchivePlus.Component;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Mapper;
using AutoArchivePlus.Model;
using ProjectAutoManagement.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    internal class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool openButtonIsEnabled = false;

        private ObservableCollection<Project> projects;

        private ProjectItem selected;

        private bool startAndOpen = true;

        private bool isRunning;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomePageViewModel()
        {
            initList();
        }

        private void initList()
        {
            using (BaseContext<Project> baseContext = new DBContext<Project>())
            {
                Projects = new ObservableCollection<Project>(baseContext.Entity);
                baseContext.Dispose();
            }
            // 新建按钮
            Projects.Insert(0, new Project());
        }


        #region Propertites
        public BitmapImage GetUserPicture
        {
            get
            {
                OS.CreateUserTilePath(null);
                var p = OS.GetCurrentUserPicturePath();
                if (File.Exists(p))
                {
                    return new BitmapImage(new Uri(p));
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Resources/img/xinwang-ds3-ico.jpg"));
                }
            }
        }

        public String GetUserName
        {
            get
            {
                return OS.GetCurrentUserName();
            }
        }

        public bool OpenButtonIsEnabled
        {
            get
            {
                return openButtonIsEnabled;
            }
            set
            {
                openButtonIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public string GetGreeting
        {
            get
            {
                var now = DateTime.Now;
                var greetingStr = now.Hour switch
                {
                    int i when i >= 7 && i < 12 => "Morning",
                    int i when i >= 12 && i < 13 => "Noon",
                    int i when i >= 13 && i < 17 => "Afternoon",
                    int i when i >= 17 && i < 24 => "Evening",
                    _ => "Evening"
                };
                return LanguageManager.Instance[greetingStr];
            }
        }

        public ObservableCollection<Project> Projects
        {
            get => projects;
            set
            {
                projects = value;
                OnPropertyChanged();
            }
        }

        public bool StartAndOpen
        {
            get => startAndOpen;
            set
            {
                startAndOpen = value;
                OnPropertyChanged();
            }
        }

        public bool IsRunning
        {
            get => isRunning;
            set
            {
                isRunning = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region commands

        public ICommand NewProject => new ControlCommand(obj =>
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.Owner = obj as Window;
            if (projectForm.ShowDialog())
            {
                initList();
            }
            GC.Collect();
        });

        public ICommand ProjectSelected => new ControlCommand(obj =>
        {
            if (obj is ProjectItem projectItem)
            {
                if (selected != null && selected != projectItem)
                {
                    selected.BorderBrush = null;
                    selected.Clicked = false;
                }
                selected = projectItem;
                Project project = selected.DataContext as Project;
                if (RunningProjectsManager.IsRunning(project))
                {
                    OpenButtonIsEnabled = false;
                    IsRunning = true;
                }
                else
                {
                    OpenButtonIsEnabled = selected.Clicked;
                    IsRunning = false;
                }
            }
        });

        public ICommand OpenProject => new ControlCommand(obj =>
        {
            if (selected != null && selected.Clicked)
            {
                //TODO open new page
                Project project = selected.DataContext as Project;
                IntPtr handle = Program.execute(project.InstallPath, onProgramExit, onExecuteError);
                IsRunning = handle != IntPtr.Zero;
                OpenButtonIsEnabled = handle == IntPtr.Zero;
                if (IsRunning)
                {
                    RunningProjectsManager.Add(project);
                }
            }
        });

        #endregion

        #region private methods

        private void onProgramExit(object sender, EventArgs args)
        {

        }

        private void onExecuteError(Exception e)
        {
        }

        #endregion
    }
}
