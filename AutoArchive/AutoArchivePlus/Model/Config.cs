/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.DataBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchivePlus.Model
{
    [Table("Config")]
    public class Config : BaseEntity
    {
        private string content;
        private int type;

        public string Content { get => content; set => content = value; }
        public int Type { get => type; set => type = value; }
    }
}
