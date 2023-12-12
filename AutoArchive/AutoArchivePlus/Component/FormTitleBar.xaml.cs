using AutoArchivePlus.Language;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// FormTitleBar.xaml 的交互逻辑
    /// </summary>
    public partial class FormTitleBar : UserControl
    {
        public static readonly DependencyProperty TitleProperty;

        public static readonly DependencyProperty ShowCloseProperty;

        public static readonly DependencyProperty ShowMaximizeProperty;

        public static readonly DependencyProperty ShowMinimizeProperty;

        public static readonly DependencyProperty ParentWindowProperty;

        public event RoutedEventHandler CloseButtonClick;

        public event RoutedEventHandler MaximizeButtonClick;

        public event RoutedEventHandler MinimizeButtonClick;


        static FormTitleBar()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FormTitleBar), new PropertyMetadata(""));
            ShowCloseProperty= DependencyProperty.Register("ShowClose", typeof(Visibility), typeof(FormTitleBar));
            ShowMaximizeProperty = DependencyProperty.Register("ShowMaximize", typeof(Visibility), typeof(FormTitleBar));
            ShowMinimizeProperty = DependencyProperty.Register("ShowMinimize", typeof(Visibility), typeof(FormTitleBar));
            ParentWindowProperty = DependencyProperty.Register("ParentWindow", typeof(Window), typeof(FormTitleBar));
        }

        public FormTitleBar()
        {
            InitializeComponent();
        }

        public string Title {
            get {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// ShowCloseBtn
        /// </summary>
        public Visibility ShowClose
        {
            get
            {
                return (Visibility)GetValue(ShowCloseProperty);
            }
            set
            {
                SetValue(ShowCloseProperty, value);
            }
        }

        /// <summary>
        /// ShowMaximize
        /// </summary>
        public Visibility ShowMaximize
        {
            get
            {
                return (Visibility)GetValue(ShowMaximizeProperty);
            }
            set
            {
                SetValue(ShowMaximizeProperty, value);
            }
        }

        /// <summary>
        /// ShowMinimize
        /// </summary>
        public Visibility ShowMinimize
        {
            get
            {
                return (Visibility)GetValue(ShowMinimizeProperty);
            }
            set
            {
                SetValue(ShowMinimizeProperty, value);
            }
        }

        /// <summary>
        /// ParentWindow
        /// </summary>
        public Window ParentWindow
        {
            get
            {
                return (Window)GetValue(ParentWindowProperty);
            }
            set
            {
                SetValue(ParentWindowProperty, value);
            }
        }

        /// <summary>
        /// On close Btn click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CloseButtonClick != null)
            {
                CloseButtonClick.Invoke(sender, e);
            }
            else
            {
                ParentWindow?.Close();
            }
        }

        /// <summary>
        /// Maximize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MaximizeButtonClick != null)
            {
                MaximizeButtonClick.Invoke(sender, e);
            }
            else
            {
                if (ParentWindow != null)
                {
                    if(ParentWindow.WindowState == WindowState.Maximized)
                    {
                        ParentWindow.WindowState=WindowState.Normal;
                        closeBtn.ToolTip = LanguageManager.Instance["MaximizeBtnName"];
                    }
                    else
                    {
                        ParentWindow.WindowState = WindowState.Maximized;
                        closeBtn.ToolTip = LanguageManager.Instance["RestoreBtnName"];
                    }
                }
            }
        }

        /// <summary>
        /// Minimize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MinimizeButtonClick != null)
            {
                MinimizeButtonClick.Invoke(sender, e);
            }
            else
            {
                if (ParentWindow != null)
                {
                    ParentWindow.WindowState = WindowState.Minimized;
                }
            }
        }
    }
}
