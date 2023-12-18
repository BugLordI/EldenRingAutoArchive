using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// NavigationMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class NavigationMenuItem : UserControl
    {
        #region Properties

        public static readonly DependencyProperty ItemNameProperty;

        public static readonly DependencyProperty ItemIconProperty;

        public static readonly DependencyProperty TestProperty;

        #endregion

        static NavigationMenuItem()
        {
            ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(FormTitleBar));
            ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(ImageSource), typeof(FormTitleBar));
            TestProperty= DependencyProperty.Register("Test", typeof(string), typeof(FormTitleBar));
        }

        public NavigationMenuItem()
        {
            InitializeComponent();
        }

        public string Test
        {
            get
            {
                return (string)GetValue(TestProperty);
            }
            set
            {
                SetValue(TestProperty, value);
            }
        }

        public string ItemName
        {
            get
            {
                return (string)GetValue(ItemNameProperty);
            }
            set
            {
                SetValue(ItemNameProperty, value);
            }
        }

        public ImageSource ItemIcon
        {
            get
            {
                return (ImageSource)GetValue(ItemIconProperty);
            }
            set
            {
                SetValue(ItemIconProperty, value);
            }
        }
    }
}
