using AutoArchive.DataBase;
using AutoArchive.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoArchive.Mapper
{
    public class BaseMapper<T> : BaseContext<T> where T : BaseEntity
    {
        public override DbSet<T> Entity { set; get; }

        public override void Configuring(DbContextOptionsBuilder optionsBuilder)
        {
            AppSetting appSetting = new AppSetting("appsettings.json");
            String connStr = appSetting["ConnectionStrings:DBConnection"];
            optionsBuilder.UseSqlite(connStr ?? "Data Source=save.db");
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int add(T entity)
        {
            int effectRows = 0;
            T one = Entity.Find(entity.Id);
            if (one == null)
            {
                Entity.Add(entity);
                effectRows = SaveChanges();
            }
            return effectRows;
        }
    }
}
