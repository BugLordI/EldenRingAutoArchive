using AutoArchivePlus.Component;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// Navigation.xaml 的交互逻辑
    /// </summary>
    public partial class Navigation : UserControl
    {
        private Control selectedItem;

        private Color defaultSelectedColor = Color.FromRgb(234, 234, 234);

        public Navigation()
        {
            InitializeComponent();
            // set default selected
            selectedItem = homeMenuItem;
        }

        public void addMenu(String menuName, String icon = "pack://application:,,,/Resources/img/xinwang-ds3-ico.jpg")
        {
            NavigationMenuItem navigationMenuItem = new NavigationMenuItem();
            navigationMenuItem.ItemName = menuName;
            menu.Children.Add(navigationMenuItem);
        }

        private void changeSelected(Control clicked)
        {
            selectedItem.Background = Brushes.Transparent;
            clicked.Background = new SolidColorBrush(defaultSelectedColor);
            this.selectedItem = clicked;
        }

        private void itemClicked(object sender, RoutedEventArgs e)
        {
            changeSelected((Control)sender);
        }
    }
}
