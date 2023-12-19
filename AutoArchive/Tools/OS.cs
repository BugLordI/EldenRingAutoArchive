using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tools
{
    public class OS
    {
        [DllImport("shell32.dll", EntryPoint = "#261", CharSet = CharSet.Unicode)]
        public static extern void GetUserTilePath(string username,UInt32 whatever, StringBuilder picpath, int maxLength);

        public static string CreateUserTilePath(string username)
        {   
            var sb = new StringBuilder(1000);
            GetUserTilePath(null, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static String GetCurrentUserPicturePath() {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp";
        }

        public static String GetCurrentUserName()
        {
            return Environment.UserName;
        }

        public static void LoadInstalledApps()
        {
            try
            {
                // 打开已安装程序的列表  
                RegistryKey installedApps = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                // 遍历已安装程序的列表  
                foreach (string skName in installedApps.GetSubKeyNames())
                {
                    try
                    {
                        // 打开已安装程序的详细信息  
                        RegistryKey sk = installedApps.OpenSubKey(skName);
                        string displayName = sk.GetValue("DisplayName") as string;
                        string uninstallString = sk.GetValue("UninstallString") as string;
                        string iconLocation = sk.GetValue("DisplayIcon") as string;
                        string publisher = sk.GetValue("Publisher") as string;
                        string installDate = sk.GetValue("InstallDate") as string;
                        string uninstallDate = sk.GetValue("InstallDate") as string;
                        string version = sk.GetValue("Version") as string;
                        string size = sk.GetValue("Size") as string;
                        string bits = sk.GetValue("Bits") as string;
                        string locale = sk.GetValue("Locale") as string;
                        string is64bit = sk.GetValue("Is64Bit") as string;
                        string parentDisplayName = sk.GetValue("ParentDisplayName") as string;
                        string parentPublisher = sk.GetValue("ParentPublisher") as string;
                        string parentIconPath = sk.GetValue("ParentIconPath") as string;
                        string isFeaturedApp = sk.GetValue("IsFeaturedApp") as string;
                        string uninstallIconPath = sk.GetValue("UninstallIconPath") as string;
                        string isInUse = sk.GetValue("IsInUse") as string;
                        string uninstallTime = sk.GetValue("UninstallTime") as string;
                        string uninstallDateTS = sk.GetValue("UninstallDateTS") as string;
                        string installFailReason = sk.GetValue("InstallFailReason") as string;
                        string installFailReasonCode = sk.GetValue("InstallFailReasonCode") as string;
                        string uninstallFailReason = sk.GetValue("UninstallFailReason") as string;
                        string uninstallFailReasonCode = sk.GetValue("UninstallFailReasonCode") as string;
                        string installType = sk.GetValue("InstallType") as string;
                        string installedBy = sk.GetValue("InstalledBy") as string;
                        string user_remove_policy = sk.GetValue("User_Remove_Policy") as string;
                        string admin_remove_policy = sk.GetValue("Admin_Remove_Policy") as string;
                        string uninstall_queue_name = sk.GetValue("Uninstall_Queue_Name") as string;
                        string uninstall_queue_ts = sk.GetValue("Uninstall_Queue_TS") as string;
                        string uninstall_queue_index = sk.GetValue("Uninstall_Queue_Index") as string;
                        string uninstall_queue_parent_name = sk.GetValue("Uninstall_Queue_Parent_Name") as string;
                    }
                    catch (Exception)
                    {
                        // 跳过异常处理，因为可能没有某个值或读取失败等异常情况发生。  
                    }
                }
            }
            catch (Exception)
            {
                // 处理异常情况，例如读取注册表失败等。  
            }
        }
    }
}
