using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// ProjectInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectInfoPage : UserControl
    {
        #region properties

        public static readonly DependencyProperty projectNameProperty;
        public static readonly DependencyProperty backupPathProperty;
        public static readonly DependencyProperty archivePathProperty;
        public static readonly DependencyProperty projectIconProperty;

        #endregion

        static ProjectInfoPage()
        {
            projectNameProperty = DependencyProperty.Register("ProjectName", typeof(String), typeof(ProjectInfoPage));
            backupPathProperty = DependencyProperty.Register("BackupPath", typeof(String), typeof(ProjectInfoPage));
            archivePathProperty = DependencyProperty.Register("ArchivePath", typeof(String), typeof(ProjectInfoPage));
            projectIconProperty = DependencyProperty.Register("ProjectIcon", typeof(String), typeof(ProjectInfoPage));
        }

        public ProjectInfoPage()
        {
            InitializeComponent();
        }

        #region properties

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
    }
}
