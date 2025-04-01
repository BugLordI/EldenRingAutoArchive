/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.DataBase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchive.Entity
{
    [Table("Target")]
    public class Target: BaseEntity
    {
        private String path;
        private String remark;
        private long dateTimeStamp;
        private String sourceId;

        public string Path { get => path; set => path = value; }
        public string Remark { get => remark; set => remark = value; }
        public long DateTimeStamp { get => dateTimeStamp; set => dateTimeStamp = value; }
        public string SourceId { get => sourceId; set => sourceId = value; }
    }
}
