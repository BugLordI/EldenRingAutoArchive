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
