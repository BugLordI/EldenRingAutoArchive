/*************************************************************************************
 *
 * 文 件 名:   BaseContext.cs
 * 描    述:   EF操作基类，所有数据操作类都需要继承此类
 * 
 * 版    本：  V1.0
 * 创 建 者：  ZhangMuYu 
 * 创建时间：  2022/06/19 14:23:07
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
using AutoArchive.Entity;
using AutoArchive.Tools;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoArchive.Mapper.DB
{
    /// <summary>
    /// 数据实体操作基类，可自行扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseContext<T> : DbContext where T : BaseEntity
    {
        public BaseContext() : base()
        {
            //如果要访问的数据库存在，则不做操作，如果不存在，会自动创建所有数据表和模式
            Database.EnsureCreated();
        }

        /// <summary>
        /// 配置链接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppSetting appSetting = new AppSetting("appsettings.json");
            String connStr = appSetting["ConnectionStrings:DBConnection"];
            optionsBuilder.UseSqlite(connStr);
        }

        /// <summary>
        /// 对象实体集合
        /// </summary>
        public abstract DbSet<T> Entity { set; get; }
    }
}
