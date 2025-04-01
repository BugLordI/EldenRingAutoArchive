/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchivePlus.Command;
using AutoArchivePlus.Forms;
using AutoArchivePlus.Language;
using AutoArchivePlus.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AutoArchivePlus.ViewModel
{
    public class NavigationViewModel : BaseViewModel
    {
        private ObservableCollection<Project> projects;

        public NavigationViewModel()
        {
            projects = new ObservableCollection<Project>
            {
                new Project
                {
                    Name = LanguageManager.Instance["Home"],
                    ImageLocation="pack://application:,,,/Resources/img/home.png",
                    IsSelect = true,
                    Id=Constant.HOME_PAGE_ID
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

        public ICommand Setting => new ControlCommand(obj =>
        {
            AppSettingForm appSettingForm = new AppSettingForm();
            appSettingForm.Owner = App.GetMainWindow();
            appSettingForm.ShowDialog();
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
