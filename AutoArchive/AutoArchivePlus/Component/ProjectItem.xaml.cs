/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchivePlus.Language;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// ProjectItem.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectItem : UserControl
    {
        #region properties

        public static readonly DependencyProperty projectTitleProperty;
        public static readonly DependencyProperty projectBackupLocationProperty;
        public static readonly DependencyProperty projectIconProperty;
        public static readonly DependencyProperty newProjectCommandProperty;
        public static readonly DependencyProperty newProjectCommandParamsProperty;
        public static readonly DependencyProperty selectedCommandProperty;
        // context menu
        public static readonly DependencyProperty openInstallPathCommandProperty;
        public static readonly DependencyProperty openArchivePathCommandProperty;
        public static readonly DependencyProperty openBackupPathCommandProperty;
        public static readonly DependencyProperty deleteCommandProperty;
        public static readonly DependencyProperty editCommandProperty;

        #endregion

        private bool clicked;

        static ProjectItem()
        {
            projectTitleProperty = DependencyProperty.Register("ProjectTitle", typeof(string), typeof(ProjectItem));
            projectBackupLocationProperty = DependencyProperty.Register("ProjectBackupLocation", typeof(string), typeof(ProjectItem));
            projectIconProperty = DependencyProperty.Register("ProjectIconLocation", typeof(ImageSource), typeof(ProjectItem));
            newProjectCommandProperty = DependencyProperty.Register("NewProjectCommand", typeof(ICommand), typeof(ProjectItem));
            newProjectCommandParamsProperty = DependencyProperty.Register("NewProjectCommandParams", typeof(Object), typeof(ProjectItem));
            selectedCommandProperty = DependencyProperty.Register("SelectedCommand", typeof(ICommand), typeof(ProjectItem));
            // context menu
            openInstallPathCommandProperty = DependencyProperty.Register("OpenInstallPathCommand", typeof(ICommand), typeof(ProjectItem));
            openArchivePathCommandProperty = DependencyProperty.Register("OpenArchivePathCommand", typeof(ICommand), typeof(ProjectItem));
            openBackupPathCommandProperty = DependencyProperty.Register("OpenBackupPathCommand", typeof(ICommand), typeof(ProjectItem));
            deleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(ProjectItem));
            editCommandProperty = DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(ProjectItem));
        }

        public ProjectItem()
        {
            InitializeComponent();
        }

        private void self_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ProjectTitle) || String.IsNullOrEmpty(ProjectBackupLocation))
            {
                defaultShow.Visibility = Visibility.Visible;
                projectIcon.Visibility = Visibility.Collapsed;
                projectInfo.Visibility = Visibility.Collapsed;
            }
            else
            {
                defaultShow.Visibility = Visibility.Collapsed;
                projectIcon.Visibility = Visibility.Visible;
                projectInfo.Visibility = Visibility.Visible;
                self.ToolTip = $"{LanguageManager.Instance["RightClickToSeeMore"]}\n" +
                               $"{LanguageManager.Instance["GameName"]}  {ProjectTitle}\n" +
                               $"{LanguageManager.Instance["GameBackupPath"]}  {ProjectBackupLocation}";
            }
            deleteMenu.Command = DeleteCommand;
            deleteMenu.CommandParameter = this.DataContext;
            openBackupMenu.Command = OpenBackupPathCommand;
            openBackupMenu.CommandParameter = this.DataContext;
            openArchivMenu.Command = OpenArchivePathCommand;
            openArchivMenu.CommandParameter = this.DataContext;
            openProgramMenu.Command = OpenInstallPathCommand;
            openProgramMenu.CommandParameter = this.DataContext;
            editMenu.Command = EditCommand;
            editMenu.CommandParameter = this.DataContext;
        }

        #region properties

        public string ProjectTitle
        {
            get
            {
                return (string)GetValue(projectTitleProperty);
            }
            set
            {
                SetValue(projectTitleProperty, value);
            }
        }

        public string ProjectBackupLocation
        {
            get
            {
                return (string)GetValue(projectBackupLocationProperty);
            }
            set
            {
                SetValue(projectBackupLocationProperty, value);
            }
        }

        public ImageSource ProjectIconLocation
        {
            get
            {
                return (ImageSource)GetValue(projectIconProperty);
            }
            set
            {
                SetValue(projectIconProperty, value);
            }
        }

        public ICommand NewProjectCommand
        {
            get
            {
                return (ICommand)GetValue(newProjectCommandProperty);
            }
            set
            {
                SetValue(newProjectCommandProperty, value);
            }
        }

        public Object NewProjectCommandParams
        {
            get
            {
                return GetValue(newProjectCommandParamsProperty);
            }
            set
            {
                SetValue(newProjectCommandParamsProperty, value);
            }
        }

        public ICommand SelectedCommand
        {
            get
            {
                return (ICommand)GetValue(selectedCommandProperty);
            }
            set
            {
                SetValue(selectedCommandProperty, value);
            }
        }

        public bool Clicked { get => clicked; set => clicked = value; }

        public ICommand OpenInstallPathCommand
        {
            get
            {
                return (ICommand)GetValue(openInstallPathCommandProperty);
            }
            set
            {
                SetValue(openInstallPathCommandProperty, value);
            }
        }

        public ICommand OpenArchivePathCommand
        {
            get
            {
                return (ICommand)GetValue(openArchivePathCommandProperty);
            }
            set
            {
                SetValue(openArchivePathCommandProperty, value);
            }
        }

        public ICommand OpenBackupPathCommand
        {
            get
            {
                return (ICommand)GetValue(openBackupPathCommandProperty);
            }
            set
            {
                SetValue(openBackupPathCommandProperty, value);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return (ICommand)GetValue(deleteCommandProperty);
            }
            set
            {
                SetValue(deleteCommandProperty, value);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return (ICommand)GetValue(editCommandProperty);
            }
            set
            {
                SetValue(editCommandProperty, value);
            }
        }

        #endregion

        #region events

        private void self_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.ShadowDepth = 3;  
            shadow.BlurRadius = 5; 
            shadow.Color = Color.FromRgb(212, 211, 209);
            self.Effect = shadow;
            if (!clicked)
            {
                self.BorderBrush = new SolidColorBrush(Colors.Gold);
            }
        }

        private void self_MouseLeave(object sender, MouseEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.ShadowDepth = 1;
            shadow.BlurRadius = 5;
            shadow.Color = Color.FromRgb(212, 211, 209);
            self.Effect = shadow;
            if (!clicked)
            {
                self.BorderBrush = null;
            }
        }

        private void self_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (!String.IsNullOrEmpty(ProjectTitle) && !String.IsNullOrEmpty(ProjectBackupLocation))
                {
                    clicked = !clicked;
                    self.BorderBrush = new SolidColorBrush(Colors.Blue);
                    SelectedCommand?.Execute(self);
                }
            }
        }

        private void defaultShowText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                NewProjectCommand?.Execute(NewProjectCommandParams);
            }
        }

        private void defaultShowText_MouseEnter(object sender, MouseEventArgs e)
        {
            defaultShowText.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void defaultShowText_MouseLeave(object sender, MouseEventArgs e)
        {
            defaultShowText.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void self_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (String.IsNullOrEmpty(ProjectTitle) || String.IsNullOrEmpty(ProjectBackupLocation))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
