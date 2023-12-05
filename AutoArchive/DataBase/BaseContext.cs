/*************************************************************************************
 *
 * 文 件 名:   BaseContext.cs
 * 描    述:   EF操作基类，所有数据操作类都需要继承此类
 * 
 * 创 建 者：  BugLord 
 * 创建时间：  2022/06/19 14:23:07
*************************************************************************************/
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoArchive.DataBase
{
    /// <summary>
    /// 数据实体操作基类，可自行扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseContext<T> : DbContext where T : BaseEntity
    {

        public BaseContext() : base()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// 配置链接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.Configuring(optionsBuilder);
        }

        /// <summary>
        /// 对象实体集合
        /// </summary>
        public abstract DbSet<T> Entity { set; get; }

        /// <summary>
        /// 配置数据库链接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        public abstract void Configuring(DbContextOptionsBuilder optionsBuilder);
    }
}
