using AutoArchive.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutoArchivePlus.Model
{
    [Table("Projects")]
    public class Project : BaseEntity
    {
        private String name;
        private String installPath;
        private String archivePath;
        private String backupPath;
        private String imageLocation;
        private List<Backup> backups;
        private bool isSelect;

        public String Name { get => name; set => name = value; }
        public String ArchivePath { get => archivePath; set => archivePath = value; }
        public String BackupPath { get => backupPath; set => backupPath = value; }
        public String InstallPath { get => installPath; set => installPath = value; }
        public List<Backup> Backups { get => backups; set => backups = value; }
        public string ImageLocation { get => imageLocation; set => imageLocation = value; }

        [NotMapped]
        public ImageSource Ico
        {
            get
            {
                if (File.Exists(ImageLocation) || (ImageLocation != null && ImageLocation.Contains("pack:")))
                {
                    return new BitmapImage(new Uri(ImageLocation));
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Resources/img/xinwang-ds3-ico.jpg"));
                }
            }
        }

        [NotMapped]
        public bool IsSelect
        {
            get
            {
                return isSelect;
            }
            set
            {
                isSelect = value;
                OnPropertyChanged();
            }
        }
    }
}
