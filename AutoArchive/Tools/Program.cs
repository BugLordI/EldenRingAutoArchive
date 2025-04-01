/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProjectAutoManagement.Utils
{
    public class Program
    {
        public static IntPtr execute(String path, EventHandler exitCallBack, Action<Exception> executeError,
            String command = null)
        {
            try
            {
                Process proc = Process.Start(path, command);
                if (proc != null)
                {
                    proc.EnableRaisingEvents = true;
                    proc.Exited += exitCallBack;
                    return proc.Handle;
                }
            }
            catch (Exception e)
            {
                executeError.Invoke(e);
            }
            return IntPtr.Zero;
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        public static void kill(IntPtr handle)
        {
            TerminateProcess(handle, 1);
        }

    }
}
