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
        #region events

        public event MouseButtonEventHandler newProjectClicked;

        #endregion

        #region properties

        public static readonly DependencyProperty showProperty;

        #endregion

        public ProjectItem()
        {
            InitializeComponent();
        }

        private void self_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.ShadowDepth = 1;  
            shadow.BlurRadius = 5; 
            shadow.Color = Colors.Gold;  
            self.Effect = shadow; 
        }

        private void self_MouseLeave(object sender, MouseEventArgs e)
        {
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.ShadowDepth = 3;
            shadow.BlurRadius = 5;
            shadow.Color = Color.FromRgb(212, 211, 209);
            self.Effect = shadow;
        }

        private void defaultShowText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            newProjectClicked?.Invoke(sender, e);
        }
    }
}
