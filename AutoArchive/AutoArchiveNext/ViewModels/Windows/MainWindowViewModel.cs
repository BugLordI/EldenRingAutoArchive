using AutoArchiveNext.Services;
using AutoArchiveNext.Views.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace AutoArchiveNext.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = LocalizationService.Instance.GetString("AppTitle");

        [ObservableProperty]
        private ObservableCollection<object> _menuItems =
        [
            new NavigationViewItem()
            {
                Content = LocalizationService.Instance.GetString("HomeViewTitle"),
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Data",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(DataPage)
            }
        ];

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems =
        [
            new NavigationViewItem()
            {
                Content = LocalizationService.Instance.GetString("SettingsViewTitle"),
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(SettingsPage)
            }
        ];

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems =
        [
            new MenuItem { Header = "Home", Tag = "tray_home" }
        ];

        [ObservableProperty]
        private Visibility _pageTitleVisibility = Visibility.Visible;

        [RelayCommand]
        public void Navigated(Object param)
        {
            if (param is NavigatedEventArgs args && args.Page.GetType() == typeof(DashboardPage))
            {
                PageTitleVisibility = Visibility.Collapsed;
            }
            else
            {
                PageTitleVisibility = Visibility.Visible;
            }
        }
    }
}
