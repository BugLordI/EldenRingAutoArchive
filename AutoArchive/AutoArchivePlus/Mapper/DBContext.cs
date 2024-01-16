using AutoArchive.DataBase;
using AutoArchive.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Windows;

namespace AutoArchivePlus.Mapper
{
    public class DBContext<T> : BaseContext<T> where T : BaseEntity
    {
        public static String connStr;

        public override DbSet<T> Entity { set; get; }


        public override void Configuring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connStr == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                AppSetting appSetting = new AppSetting(Path.Combine(path, "AppConfig.json"));
                connStr = appSetting["ConnectionStrings:DBConnection"];
            }
            optionsBuilder.UseSqlite(connStr ?? "Data Source=save.db");
        }
    }
}
