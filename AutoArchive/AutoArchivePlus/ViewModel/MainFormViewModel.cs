using AutoArchivePlus.Command;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tools;

namespace AutoArchivePlus.ViewModel
{
    internal class MainFormViewModel
    {
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
    }
}
