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
    /// ProjectInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectInfoPage : UserControl
    {
        public ProjectInfoPage()
        {
            InitializeComponent();
        }

        private void onMouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(64, 158, 255));
        }

        private void onMouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Foreground = Brushes.Black;
        }

        private void projectInfoPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(64, 158, 255));
        }

        private void projectInfoPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.BorderBrush = Brushes.LightGray;
        }
    }
}
