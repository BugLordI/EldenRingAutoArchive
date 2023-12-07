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

        public event RoutedEventHandler closeBtnClickHandler;

        static FormTitleBar()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FormTitleBar), new PropertyMetadata(""));
            ShowCloseProperty= DependencyProperty.Register("ShowClose", typeof(string), typeof(FormTitleBar), new PropertyMetadata(""));
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
        /// set value is "true" or "false"
        /// </summary>
        public string ShowClose
        {
            get
            {
                return (string)GetValue(ShowCloseProperty);
            }
            set
            {
                if (value.ToLower() == "true")
                {
                    SetValue(ShowCloseProperty, "Visible");
                }
                else {
                    SetValue(ShowCloseProperty, "Hidden");
                }
            }
        }

        private void closeBtn_MouseDown(object sender, RoutedEventArgs e)
        {
            closeBtnClickHandler(sender, e);
        }
    }
}
