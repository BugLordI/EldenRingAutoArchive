using AutoArchiveNext.Services;
using System.IO;
using System.Windows.Media.Imaging;
using Tools;

namespace AutoArchiveNext.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private BitmapImage _userPicture;

        [ObservableProperty]
        private String _greeting;

        [ObservableProperty]
        private String _userName;

        public DashboardViewModel()
        {
            _userPicture = GetUserPicture();
            _greeting = GetGreeting();
            _userName = OS.GetCurrentUserName();
        }

        private BitmapImage GetUserPicture()
        {
            OS.CreateUserTilePath();
            var p = OS.GetCurrentUserPicturePath();
            if (File.Exists(p))
            {
                return new BitmapImage(new Uri(p));
            }
            else
            {
                return new BitmapImage(new Uri("pack://application:,,,/Properties/Imgs/xinwang-ds3-ico.jpg"));
            }
        }

        private string GetGreeting()
        {
            var now = DateTime.Now;
            var greetingStr = now.Hour switch
            {
                int i when i >= 4 && i < 12 => "Morning",
                int i when i >= 12 && i < 13 => "Noon",
                int i when i >= 13 && i < 17 => "Afternoon",
                int i when i >= 17 && i < 22 => "Evening",
                _ => "MidNight"
            };
            return LocalizationService.Instance.GetString(greetingStr);
        }

    }
}
