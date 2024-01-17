using AutoArchivePlus.ViewModel;
using AutoArchivePlus.WindowTools;
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

        public ProjectForm()
        {
            InitializeComponent();
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return dataHasChanged;
        }

        private void projectForm_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectFormViewModel dc = DataContext as ProjectFormViewModel;
            if (String.IsNullOrEmpty(gameBackupPath.Text))
            {
                String des = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AutoArchive");
                dc.GameBackupPath = des;
            }
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

        private void chooseBackupPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ProjectFormViewModel dc = DataContext as ProjectFormViewModel;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderBrowser.ShowDialog(this.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                dc.GameBackupPath = folderBrowser.SelectedPath;
            }
        }

        private void chooseArchivePath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ProjectFormViewModel dc = DataContext as ProjectFormViewModel;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderBrowser.ShowDialog(this.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                dc.GameArchivePath = folderBrowser.SelectedPath;
            }
        }

        private void chooseGamePath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ProjectFormViewModel dc = DataContext as ProjectFormViewModel;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = openFileDialog.ShowDialog(this.GetIWin32Window());
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                dc.GameInstallPath = openFileDialog.FileName;
            }
        }
    }
}
