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

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// ProjectForm.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectForm : Window
    {
        public bool dataHasChanged;

        public bool isEditModel;

        public Action loadData;

        public ProjectForm()
        {
            InitializeComponent();
        }

        public ProjectForm(bool isEdit) : this()
        {
            this.isEditModel = isEdit;
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return dataHasChanged;
        }

        private void projectForm_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(gameBackupPath.Text))
            {
                String des = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AutoArchive");
                dc.GameBackupPath = des;
            }
            if (isEditModel)
            {
                titleBar.Title = LanguageManager.Instance["Edit"];
            }
            else
            {
                titleBar.Title = LanguageManager.Instance["NewProject"];
            }
            loadData?.Invoke();
        }

        private void commonLink_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void commonLink_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(64, 158, 255));
        }
    }
}
