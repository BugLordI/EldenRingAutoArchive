using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace AutoArchivePlus.WindowTools
{
    internal static class KeyListener
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static void RegisterHotKey(this Window window, int keyEventId, Key key, ModifierKeys modifierKeys
            , HwndSourceHook hook)
        {
            var handle = new WindowInteropHelper(window).Handle;
            var source = HwndSource.FromHwnd(handle);
            source?.AddHook(hook);
            RegisterHotKey(handle, keyEventId, (uint)modifierKeys, (uint)KeyInterop.VirtualKeyFromKey(key));
        }

        public static void UnregisterHotKey(this Window window, int keyEventId)
        {
            var handle = new WindowInteropHelper(window).Handle;
            UnregisterHotKey(handle, keyEventId);
        }
    }
}
