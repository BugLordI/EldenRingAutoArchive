using System.Windows;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// MainForm.xaml 的交互逻辑
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void titleBar_cloesBtnmouseDown(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
