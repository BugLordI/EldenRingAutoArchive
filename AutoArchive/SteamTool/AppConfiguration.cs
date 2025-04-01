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
    public class AppConfiguration
    {
        private String appId;
        private String savedPath;
        private String savedFileName;
        private String executable;

        public string AppId { get => appId; set => appId = value; }
        public string SavedPath { get => savedPath; set => savedPath = value; }
        public string SavedFileName { get => savedFileName; set => savedFileName = value; }
        public string Executable { get => executable; set => executable = value; }
    }
}
