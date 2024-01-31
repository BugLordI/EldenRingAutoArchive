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
