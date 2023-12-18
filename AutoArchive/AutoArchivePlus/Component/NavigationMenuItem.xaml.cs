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

        public static readonly DependencyProperty ItemIconWidthProperty;

        public static readonly DependencyProperty ItemIconHeightProperty;

        public static readonly DependencyProperty ItemSelectedProperty;

        #endregion

        static NavigationMenuItem()
        {
            ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(NavigationMenuItem));
            ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(ImageSource), typeof(NavigationMenuItem));
            ItemIconWidthProperty= DependencyProperty.Register("ItemIconWidth", typeof(double), typeof(NavigationMenuItem));
            ItemIconHeightProperty = DependencyProperty.Register("ItemIconHeight", typeof(double), typeof(NavigationMenuItem));
            ItemSelectedProperty = DependencyProperty.Register("ItemSelected", typeof(Brush), typeof(NavigationMenuItem));
        }

        public NavigationMenuItem()
        {
            InitializeComponent();
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

        public double ItemIconWidth
        {
            get
            {
                return (double)GetValue(ItemIconWidthProperty);
            }
            set
            {
                SetValue(ItemIconWidthProperty, value);
            }
        }

        public double ItemIconHeight
        {
            get
            {
                return (double)GetValue(ItemIconHeightProperty);
            }
            set
            {
                SetValue(ItemIconHeightProperty, value);
            }
        }

        public Brush ItemSelected
        {
            get
            {
                return (Brush)GetValue(ItemSelectedProperty);
            }
            set
            {
                SetValue(ItemSelectedProperty, value);
            }
        }
    }
}
