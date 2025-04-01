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

namespace AutoArchivePlus.Model
{
    [Table("Backups")]
    public class Backup : BaseEntity
    {
        private String path;
        private String remark;
        private long dateTimeStamp;
        private String projectId;

        public String Path { get => path; set => path = value; }
        public String Remark { get => remark; set => remark = value; }
        public long DateTimeStamp { get => dateTimeStamp; set => dateTimeStamp = value; }
        public String ProjectId { get => projectId; set => projectId = value; }
    }
}
