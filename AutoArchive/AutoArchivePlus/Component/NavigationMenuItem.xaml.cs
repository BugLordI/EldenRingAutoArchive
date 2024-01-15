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
        #region events

        public event RoutedEventHandler ItemClicked;

        #endregion

        #region Properties

        public static readonly DependencyProperty TypeNameProperty;

        public static readonly DependencyProperty ItemNameProperty;

        public static readonly DependencyProperty ItemIconProperty;

        public static readonly DependencyProperty ItemIconWidthProperty;

        public static readonly DependencyProperty ItemIconHeightProperty;

        public static readonly DependencyProperty ItemIconMarginProperty;

        public static readonly DependencyProperty ItemSelectedProperty;

        public static readonly DependencyProperty FontColorProperty;

        public static readonly DependencyProperty IsSelectProperty;

        public static readonly DependencyProperty BorderRootThicknessProperty;

        #endregion

        static NavigationMenuItem()
        {
            TypeNameProperty = DependencyProperty.Register("TypeName", typeof(string), typeof(NavigationMenuItem));
            ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(NavigationMenuItem));
            ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(ImageSource), typeof(NavigationMenuItem));
            ItemIconWidthProperty = DependencyProperty.Register("ItemIconWidth", typeof(double), typeof(NavigationMenuItem));
            ItemIconHeightProperty = DependencyProperty.Register("ItemIconHeight", typeof(double), typeof(NavigationMenuItem));
            ItemIconMarginProperty = DependencyProperty.Register(" ItemIconMargin", typeof(Thickness), typeof(NavigationMenuItem), new PropertyMetadata(new Thickness(7, 0, 0, 0)));
            ItemSelectedProperty = DependencyProperty.Register("ItemSelected", typeof(Brush), typeof(NavigationMenuItem));
            FontColorProperty = DependencyProperty.Register("FontColor", typeof(Brush), typeof(NavigationMenuItem));
            IsSelectProperty = DependencyProperty.Register("IsSelect", typeof(bool), typeof(NavigationMenuItem));
            //BorderRootThicknessProperty = DependencyProperty.Register("BorderRootThickness", typeof(Thickness), typeof(NavigationMenuItem));
        }

        public NavigationMenuItem()
        {
            InitializeComponent();
            FontColor = Brushes.Black;
        }

        public string TypeName
        {
            get
            {
                return (string)GetValue(TypeNameProperty);
            }
            set
            {
                SetValue(TypeNameProperty, value);
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

        public Thickness ItemIconMargin
        {
            get
            {
                return (Thickness)GetValue(ItemIconMarginProperty);
            }
            set
            {
                SetValue(ItemIconMarginProperty, value);
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

        public Brush FontColor
        {
            get
            {
                return (Brush)GetValue(FontColorProperty);
            }
            set
            {
                SetValue(FontColorProperty, value);
            }
        }

        public bool IsSelect
        {
            get
            {
                return (bool)GetValue(IsSelectProperty);
            }
            set
            {
                SetValue(IsSelectProperty, value);
            }
        }

        public Thickness BorderRootThickness
        {
            get
            {
                if (IsSelect)
                {
                    return new Thickness(3, 2, 0, 0);
                }
                else
                {
                    return new Thickness(0, 0, 0, 0);
                }
            }
            private set
            {
                SetValue(BorderRootThicknessProperty, value);
            }
        }

        private void defaultMenu_Click(object sender, RoutedEventArgs e)
        {
            ItemClicked?.Invoke(this, e);
        }
    }
}
