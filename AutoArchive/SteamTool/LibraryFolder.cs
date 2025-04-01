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
    internal class LibraryFolder
    {
        private String path;
        private String label;
        private String contentid;
        private String totalsize;
        private String update_clean_bytes_tally;
        private String time_last_update_corruption;

        public string Path { get => path; set => path = value; }
        public string Label { get => label; set => label = value; }
        public string Contentid { get => contentid; set => contentid = value; }
        public string Totalsize { get => totalsize; set => totalsize = value; }
        public string Update_clean_bytes_tally { get => update_clean_bytes_tally; set => update_clean_bytes_tally = value; }
        public string Time_last_update_corruption { get => time_last_update_corruption; set => time_last_update_corruption = value; }
    }
}
