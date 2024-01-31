using AutoArchivePlus.ViewModel;
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
                String des = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AutoArchive");
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
    }
}
