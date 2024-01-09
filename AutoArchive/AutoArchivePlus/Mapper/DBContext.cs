using AutoArchive.DataBase;
using AutoArchive.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                AppSetting appSetting = new AppSetting("AppConfig.json");
                connStr = appSetting["ConnectionStrings:DBConnection"];
            }
            optionsBuilder.UseSqlite(connStr ?? "Data Source=save.db");
        }
    }
}
