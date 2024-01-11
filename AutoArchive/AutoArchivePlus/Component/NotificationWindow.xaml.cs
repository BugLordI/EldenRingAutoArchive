using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// NotificationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public NotificationWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Window mainWindow = App.GetMainWindow();
            this.Top = mainWindow.Top + mainWindow.ActualHeight - this.ActualHeight - 10;
            //this.Left = mainWindow.Left + mainWindow.ActualWidth - this.ActualWidth - 10;
            Storyboard storyboard = loadingAnimation();
            storyboard.Begin();
        }

        private Storyboard loadingAnimation()
        {
            Window mainWindow = App.GetMainWindow();
            Storyboard storyboard = new Storyboard();
            // Left
            DoubleAnimationUsingKeyFrames keyFrames = new DoubleAnimationUsingKeyFrames();
            double startX = mainWindow.Left + mainWindow.ActualWidth;
            double endX = startX - this.ActualWidth-10;
            EasingDoubleKeyFrame kt1 = new EasingDoubleKeyFrame(startX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            EasingDoubleKeyFrame kt2 = new EasingDoubleKeyFrame(endX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.3)));
            keyFrames.KeyFrames.Add(kt1);
            keyFrames.KeyFrames.Add(kt2);
            storyboard.Children.Add(keyFrames);
            // Width
            DoubleAnimationUsingKeyFrames keyFrames1 = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame kt3 = new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            EasingDoubleKeyFrame kt4 = new EasingDoubleKeyFrame(300, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.3)));
            keyFrames1.KeyFrames.Add(kt3);
            keyFrames1.KeyFrames.Add(kt4);
            storyboard.Children.Add(keyFrames1);
            Storyboard.SetTargetProperty(keyFrames, new PropertyPath(LeftProperty));
            Storyboard.SetTargetProperty(keyFrames1, new PropertyPath(WidthProperty));
            Storyboard.SetTarget(keyFrames, this);
            Storyboard.SetTarget(keyFrames1, this);
            return storyboard;
        }
    }
}
