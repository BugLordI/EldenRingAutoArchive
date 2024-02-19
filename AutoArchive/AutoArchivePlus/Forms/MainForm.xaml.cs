using AutoArchivePlus.Language;
using System;
using System.Windows;
using System.Windows.Interop;
using AutoArchivePlus.WindowTools;
using Window = System.Windows.Window;
using MessageBox = System.Windows.MessageBox;
using AutoArchivePlus.Common;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Diagnostics;
using AutoArchivePlus.ViewModel;
using System.Runtime.CompilerServices;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// MainForm.xaml 的交互逻辑
    /// </summary>
    public partial class MainForm : Window
    {
        private const int WM_SETCURSOR = 0x20;

        private const int QuickBackupKeyEventId = 7135;

        public MainForm()
        {
            InitializeComponent();
            titleBar.MinimizeButtonToolTip = LanguageManager.Instance["MinimizeBtnName"];
            titleBar.MaximizeButtonToolTip = LanguageManager.Instance["MaximizeBtnName"];
            titleBar.CloseButtonToolTip = LanguageManager.Instance["CloseBtnName"];
        }

        public void Message(String message, MessageTypeEnum messageType = MessageTypeEnum.INFO)
        {
            switch (messageType)
            {
                case MessageTypeEnum.ERROR: globalErrorMessagePanel.ShowErrorMessage(message); break;
                case MessageTypeEnum.WARNING: globalMessagePanel.ShowSuccessMessage(message); break;
                case MessageTypeEnum.INFO:
                default: globalMessagePanel.ShowSuccessMessage(message); break;
            }
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(App.AppSetting.ShowEffectShadow)
            {
                DropShadowEffect effect = new DropShadowEffect()
                {
                    BlurRadius = 10,
                    Opacity = 0.9,
                    ShadowDepth = 0,
                    Color = Color.FromRgb(245, 219, 163)
                };
                this.Effect = effect;
            }
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
            if (App.AppSetting.EnableQuickBackup)
            {
                this.RegisterHotKey(QuickBackupKeyEventId, System.Windows.Input.Key.Divide, System.Windows.Input.ModifierKeys.None, HwndHook);
            }
        }

        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SETCURSOR)
            {
                if (lParam.ToInt32() == 0x202fffe || lParam.ToInt32() == 0x201fffe)
                {
                    foreach (Window child in this.OwnedWindows)
                    {
                        child.Blink();
                    }
                }
            }
            return IntPtr.Zero;
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int wmHotkey = 0x0312;
            if (msg == wmHotkey)
            {
                if (wParam.ToInt32() == QuickBackupKeyEventId)
                {
                    dc.BackupCommand.Execute(LanguageManager.Instance["QuickBackupRemark"]);
                }
            }
            return IntPtr.Zero;
        }


        /// <summary>
        /// close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBar_CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.UnregisterHotKey(QuickBackupKeyEventId);
            if (App.AppSetting.AlwaysAskWhenExits)
            {
                MessageBoxResult ret = MessageBox.Show(LanguageManager.Instance["CloseAppConfirmation"], LanguageManager.Instance["Tip"], MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window window = sender as Window;
            if (window.WindowState == WindowState.Maximized)
            {
                //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                //this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                titleBar.MaximizeButtonToolTip = LanguageManager.Instance["RestoreBtnName"];
            }
            else
            {
                titleBar.MaximizeButtonToolTip = LanguageManager.Instance["MaximizeBtnName"];
            }
        }
    }
}
