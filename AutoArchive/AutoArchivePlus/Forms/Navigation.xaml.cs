using AutoArchivePlus.Component;
using AutoArchivePlus.ViewModel;
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

        public Navigation()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationViewModel navigationViewModel = this.DataContext as NavigationViewModel;
        }

        private void changeSelected(Control clicked)
        {
            if (selectedItem != null)
            {
                selectedItem.IsSelect = false;
            }
            NavigationMenuItem menuItem = clicked as NavigationMenuItem;
            menuItem.IsSelect = true;
            this.selectedItem = menuItem;
        }

        private void itemClicked(object sender, RoutedEventArgs e)
        {
            changeSelected((Control)sender);
        }
    }
}
