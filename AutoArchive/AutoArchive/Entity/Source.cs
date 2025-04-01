/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using AutoArchive.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoArchive.Entity
{
    [Table("Resource")]
    public class Source : BaseEntity
    {
        private String name;
        private String srcPath;
        private String tarPath;
        private List<Target> targets;
        private Task task;

        public string Name { get => name; set => name = value; }
        public string SrcPath { get => srcPath; set => srcPath = value; }
        public string TarPath { get => tarPath; set => tarPath = value; }
        public List<Target> Targets { get => targets; set => targets = value; }
        public Task Task { get => task; set => task = value; }
    }
}
