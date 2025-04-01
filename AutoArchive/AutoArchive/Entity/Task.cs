/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.DataBase;
using System;

namespace AutoArchive.Entity
{
    public class Task: BaseEntity
    {
        private int taskPeriod;
        private String sourceId;
        private Boolean isOn;

        public int TaskPeriod { get => taskPeriod; set => taskPeriod = value; }
        public string SourceId { get => sourceId; set => sourceId = value; }
        public bool IsOn { get => isOn; set => isOn = value; }
    }
}
