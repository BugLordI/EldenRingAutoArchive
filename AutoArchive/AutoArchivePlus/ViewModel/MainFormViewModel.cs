using AutoArchivePlus.Command;
using AutoArchivePlus.Language;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    internal class MainFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool openButtonIsEnabled = false;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BitmapImage GetUserPicture
        {
            get
            {
                OS.CreateUserTilePath(null);
                var p = OS.GetCurrentUserPicturePath();
                if (File.Exists(p))
                {
                    return new BitmapImage(new Uri(p));
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Resources/img/xinwang-ds3-ico.jpg"));
                }
            }
        }

        public String GetUserName
        {
            get
            {
               return OS.GetCurrentUserName();
            }
        }

        public bool OpenButtonIsEnabled
        {
            get
            {
                return openButtonIsEnabled;
            }
            set
            {
                openButtonIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public string GetGreeting
        {
            get
            {
                var now = DateTime.Now;
                var greetingStr = now.Hour switch
                {
                    int i when i >= 7 && i < 12 => "Morning",
                    int i when i >= 12 && i < 13 => "Noon",
                    int i when i >= 13 && i < 17 => "Afternoon",
                    int i when i >= 17 && i < 24 => "Evening",
                    _ => "Evening"
                };
                return LanguageManager.Instance[greetingStr];
            }
        }
    }
}
