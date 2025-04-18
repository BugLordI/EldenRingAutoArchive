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
using System.IO;

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
                connStr = App.ConfigReader["ConnectionStrings:DBConnection"];
            }
            optionsBuilder.UseSqlite(connStr ?? "Data Source=save.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>();
        }

        public void RemoveAll(Func<T, bool> func)
        {
            foreach (var item in Entity)
            {
                if (func(item))
                {
                    Entity.Remove(item);
                }
            }
        }
    }
}
