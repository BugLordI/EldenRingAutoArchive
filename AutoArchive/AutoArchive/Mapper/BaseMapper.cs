/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
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
            JsonConfigReader appSetting = new JsonConfigReader("appsettings.json");
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
