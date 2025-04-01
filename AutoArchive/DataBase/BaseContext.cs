/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using Microsoft.EntityFrameworkCore;

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
