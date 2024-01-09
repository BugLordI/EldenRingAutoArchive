using AutoArchive.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;

namespace AutoArchivePlus.Model
{
    [Table("Projects")]
    public class Project : BaseEntity
    {
        private String name;
        private String installPath;
        private String archivePath;
        private String backupPath;
        private List<Backup> backups;

        public String Name { get => name; set => name = value; }
        public String ArchivePath { get => archivePath; set => archivePath = value; }
        public String BackupPath { get => backupPath; set => backupPath = value; }
        public String InstallPath { get => installPath; set => installPath = value; }
        public List<Backup> Backups { get => backups; set => backups = value; }
    }
}
