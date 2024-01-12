using AutoArchivePlus.Component;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoArchivePlus.Forms
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        private Window parentWindow;

        public HomePage()
        {
            InitializeComponent();
        }

        public Window ParentWindow{ get => parentWindow; set => parentWindow = value; }

        private void ProjectItem_newProjectClicked(object sender, MouseButtonEventArgs e)
        {
            //ProjectForm projectForm = new ProjectForm();
            //projectForm.Owner = ParentWindow;
            //projectForm.ShowDialog();
            App.GlobalMessage("你好啊");
        }
    }
}
