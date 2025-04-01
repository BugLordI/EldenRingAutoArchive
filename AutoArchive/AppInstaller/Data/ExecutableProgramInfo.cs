using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppInstaller.Data
{
    [Serializable]
    internal class ExecutableProgramInfo
    {
        private String name;
        private String version;
        private String installPath;
        private String licensePath;
        private String iconPath;
        private String mainExecutablePath;
        private String excludePath;
        private bool isCreateDesktopShortcut;
        private bool isAddToStartMenu;
    }
}
