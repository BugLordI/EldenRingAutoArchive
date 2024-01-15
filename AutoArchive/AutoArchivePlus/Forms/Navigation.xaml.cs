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
        private NavigationMenuItem selectedItem;

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
            selectedItem.FontColor = Brushes.Black;
            selectedItem.IsSelect = false;
            NavigationMenuItem menuItem = clicked as NavigationMenuItem;
            menuItem.Background = new SolidColorBrush(defaultSelectedColor);
            menuItem.FontColor = new SolidColorBrush(Color.FromRgb(64, 158, 255));
            menuItem.IsSelect = true;
            this.selectedItem = menuItem;
        }

        private void itemClicked(object sender, RoutedEventArgs e)
        {
            changeSelected((Control)sender);
        }
    }
}
