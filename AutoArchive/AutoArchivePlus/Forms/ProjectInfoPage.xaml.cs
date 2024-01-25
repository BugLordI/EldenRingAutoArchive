using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// ProjectInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectInfoPage : UserControl
    {
        #region properties

        public static readonly DependencyProperty projectIdProperty;
        public static readonly DependencyProperty projectNameProperty;
        public static readonly DependencyProperty backupPathProperty;
        public static readonly DependencyProperty archivePathProperty;
        public static readonly DependencyProperty projectIconProperty;
        public static readonly DependencyProperty backupsProperty;
        public static readonly DependencyProperty backupButtonCommandProperty;
        public static readonly DependencyProperty recoverButtonCommandProperty;
        public static readonly DependencyProperty openPathButtonCommandProperty;
        public static readonly DependencyProperty deleteButtonCommandProperty;

        #endregion

        private SolidColorBrush beforeEnter;

        static ProjectInfoPage()
        {
            projectIdProperty = DependencyProperty.Register("ProjectId", typeof(String), typeof(ProjectInfoPage));
            projectNameProperty = DependencyProperty.Register("ProjectName", typeof(String), typeof(ProjectInfoPage));
            backupPathProperty = DependencyProperty.Register("BackupPath", typeof(String), typeof(ProjectInfoPage));
            archivePathProperty = DependencyProperty.Register("ArchivePath", typeof(String), typeof(ProjectInfoPage));
            projectIconProperty = DependencyProperty.Register("ProjectIcon", typeof(ImageSource), typeof(ProjectInfoPage));
            backupsProperty= DependencyProperty.Register("Backups", typeof(ObservableCollection<Object>), typeof(ProjectInfoPage));
            backupButtonCommandProperty = DependencyProperty.Register("BackupButtonCommand", typeof(ICommand), typeof(ProjectInfoPage));
            recoverButtonCommandProperty = DependencyProperty.Register("RecoverButtonCommand", typeof(ICommand), typeof(ProjectInfoPage));
            openPathButtonCommandProperty = DependencyProperty.Register("OpenPathButtonCommand", typeof(ICommand), typeof(ProjectInfoPage));
            deleteButtonCommandProperty = DependencyProperty.Register("DeleteButtonCommand", typeof(ICommand), typeof(ProjectInfoPage));
        }

        public ProjectInfoPage()
        {
            InitializeComponent();
        }

        #region properties

        public String ProjectId
        {
            get
            {
                return (String)GetValue(projectIdProperty);
            }
            set
            {
                SetValue(projectIdProperty, value);
            }
        }

        public String ProjectName
        {
            get
            {
                return (String)GetValue(projectNameProperty);
            }
            set
            {
                SetValue(projectNameProperty, value);
            }
        }

        public String BackupPath
        {
            get
            {
                return (String)GetValue(backupPathProperty);
            }
            set
            {
                SetValue(backupPathProperty, value);
            }
        }

        public String ArchivePath
        {
            get
            {
                return (String)GetValue(archivePathProperty);
            }
            set
            {
                SetValue(archivePathProperty, value);
            }
        }

        public ImageSource ProjectIcon
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

        public ObservableCollection<Object> Backups
        {
            get
            {
                return (ObservableCollection<Object>)GetValue(projectIconProperty);
            }
            set
            {
                SetValue(projectIconProperty, value);
            }
        }

        public ICommand BackupButtonCommand
        {
            get
            {
                return (ICommand)GetValue(backupButtonCommandProperty);
            }
            set
            {
                SetValue(backupButtonCommandProperty, value);
            }
        }

        public ICommand RecoverButtonCommand
        {
            get
            {
                return (ICommand)GetValue(recoverButtonCommandProperty);
            }
            set
            {
                SetValue(recoverButtonCommandProperty, value);
            }
        }

        public ICommand OpenPathButtonCommand
        {
            get
            {
                return (ICommand)GetValue(openPathButtonCommandProperty);
            }
            set
            {
                SetValue(openPathButtonCommandProperty, value);
            }
        }

        public ICommand DeleteButtonCommand
        {
            get
            {
                return (ICommand)GetValue(deleteButtonCommandProperty);
            }
            set
            {
                SetValue(deleteButtonCommandProperty, value);
            }
        }

        #endregion

        private void onMouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(64, 158, 255));
        }

        private void onMouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = Brushes.Black;
        }

        private void OpButton_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            beforeEnter = (SolidColorBrush)textBlock.Foreground;
            textBlock.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void OpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = beforeEnter;
        }

        private void recoverBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            RecoverButtonCommand?.Execute(textBlock.Tag);
        }

        private void openPathBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            OpenPathButtonCommand?.Execute(textBlock.Tag);
        }

        private void deleteBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            DeleteButtonCommand?.Execute(textBlock.Tag);
        }
    }
}
