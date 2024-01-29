using System;

namespace SteamTool
{
    public class SteamAppInfo
    {
        private String appid;

        private String name;

        private String installdir;

        public string Appid { get => appid; set => appid = value; }
        public string Name { get => name; set => name = value; }
        public string Installdir { get => installdir; set => installdir = value; }
    }
}
