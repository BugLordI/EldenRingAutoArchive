using System.Windows;
using System.Windows.Controls;

namespace AutoArchivePlus.Component
{
    /// <summary>
    /// FormTitleBar.xaml 的交互逻辑
    /// </summary>
    public partial class FormTitleBar : UserControl
    {
        public static readonly DependencyProperty TitleProperty;

        static FormTitleBar()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FormTitleBar), new PropertyMetadata(""));
        }

        public FormTitleBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title {
            get {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
    }
}
