using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Tools;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// ProjectItem.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectItem : UserControl
    {
        #region events

        public event MouseButtonEventHandler newProjectClicked;

        #endregion

        #region properties

        public static readonly DependencyProperty projectTitleProperty;
        public static readonly DependencyProperty projectBackupLocationProperty;
        public static readonly DependencyProperty projectIconProperty;

        #endregion

        static ProjectItem()
        {
            projectTitleProperty = DependencyProperty.Register("ProjectTitle", typeof(string), typeof(ProjectItem));
            projectBackupLocationProperty = DependencyProperty.Register("projectBackupLocation", typeof(string), typeof(ProjectItem));
            projectIconProperty = DependencyProperty.Register("ProjectIconLocation", typeof(BitmapImage), typeof(ProjectItem));
        }

        public ProjectItem()
        {
            InitializeComponent();
        }

        private void self_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProjectTitle == null || ProjectBackupLocation == null)
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
                self.ToolTip = ProjectTitle + "\n" + ProjectBackupLocation;
            }
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

        public BitmapImage ProjectIconLocation
        {
            get
            {
                return (BitmapImage)GetValue(projectIconProperty);
            }
            set
            {
                SetValue(projectIconProperty, value);
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
            self.BorderBrush = new SolidColorBrush(Colors.Gold);
        }

        private void self_MouseLeave(object sender, MouseEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.ShadowDepth = 1;
            shadow.BlurRadius = 5;
            shadow.Color = Color.FromRgb(212, 211, 209);
            self.Effect = shadow;
            self.BorderBrush = null;
        }

        private void defaultShowText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            newProjectClicked?.Invoke(sender, e);
        }

        private void defaultShowText_MouseEnter(object sender, MouseEventArgs e)
        {
            defaultShowText.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void defaultShowText_MouseLeave(object sender, MouseEventArgs e)
        {
            defaultShowText.Foreground = new SolidColorBrush(Colors.Blue);
        }

        #endregion

    }
}
