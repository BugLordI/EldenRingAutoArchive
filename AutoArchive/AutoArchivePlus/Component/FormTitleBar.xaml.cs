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

        public static readonly DependencyProperty ParentWindowProperty;

        public event RoutedEventHandler CloseButtonClick;

        public event MouseButtonEventHandler DragMove;

        static FormTitleBar()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FormTitleBar), new PropertyMetadata(""));
            ShowCloseProperty= DependencyProperty.Register("ShowClose", typeof(Visibility), typeof(FormTitleBar));
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
                CloseButtonClick?.Invoke(sender, e);
            }
            else
            {
                ParentWindow?.Close();
            }
        }

        /// <summary>
        /// Drag Move the parentWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove?.Invoke(sender, e);
            }
        }
    }
}
