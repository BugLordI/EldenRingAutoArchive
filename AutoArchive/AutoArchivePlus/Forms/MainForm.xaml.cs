using AutoArchivePlus.Language;
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
            titleBar.MinimizeButtonToolTip = LanguageManager.Instance["MinimizeBtnName"];
            titleBar.MaximizeButtonToolTip = LanguageManager.Instance["MaximizeBtnName"];
            titleBar.CloseButtonToolTip = LanguageManager.Instance["CloseBtnName"];
        }

        /// <summary>
        /// close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBar_CloseButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(LanguageManager.Instance["CloseAppConfirmation"], LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window window = sender as Window;
            if (window.WindowState == WindowState.Maximized)
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                titleBar.MaximizeButtonToolTip = LanguageManager.Instance["RestoreBtnName"];
            }
            else
            {
                titleBar.MaximizeButtonToolTip = LanguageManager.Instance["MaximizeBtnName"];
            }
        }
    }
}
