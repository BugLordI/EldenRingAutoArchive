using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Tools
{
    public class OS
    {
        [DllImport("shell32.dll", EntryPoint = "#261", CharSet = CharSet.Unicode)]
        public static extern void GetUserTilePath(string username,UInt32 whatever, StringBuilder picpath, int maxLength);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

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

        public static IntPtr OpenAndSelect(String path)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "explorer";
            psi.Arguments = @"/select," + path;
            Process proc = Process.Start(psi);
            var a = proc.Id;
            return proc.Handle;
        }
    }
}
