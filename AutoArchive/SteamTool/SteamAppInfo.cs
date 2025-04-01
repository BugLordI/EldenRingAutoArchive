/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;

namespace SteamTool
{
    public class SteamAppInfo
    {
        private String appid;

        private String name;

        private String installdir;

        private String executablePath;

        private String archivePath;
        public string Appid { get => appid; set => appid = value; }
        public string Name { get => name; set => name = value; }
        public string Installdir { get => installdir; set => installdir = value; }
        public string ExecutablePath { get => executablePath; set => executablePath = value; }
        public string ArchivePath { get => archivePath; set => archivePath = value; }
    }
}
