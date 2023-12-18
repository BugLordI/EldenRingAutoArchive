using AutoArchivePlus.Component;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// Navigation.xaml 的交互逻辑
    /// </summary>
    public partial class Navigation : UserControl
    {
        public Navigation()
        {
            InitializeComponent();
        }

        public void addMenu(String menuName, String icon = "pack://application:,,,/Resources/img/xinwang-ds3-ico.jpg")
        {
            NavigationMenuItem navigationMenuItem = new NavigationMenuItem();
            navigationMenuItem.ItemName = menuName;
            menu.Children.Add(navigationMenuItem);
        }
    }
}
