using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : UserControl
    {
        #region properties

        public static readonly DependencyProperty ParentWindowProperty;

        #endregion


        static HomePage()
        {
            ParentWindowProperty = DependencyProperty.Register("ParentWindow", typeof(Window), typeof(HomePage));
        }

        public HomePage()
        {
            InitializeComponent();
        }

        public Window ParentWindow
        {
            get
            {
                return (Window)GetValue(ParentWindowProperty);
            }
            set
            {
                SetValue(ParentWindowProperty, value);
            }
        }
    }
}
