/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.IO;

namespace AutoArchive.Tools
{
    /// <summary>
    /// 文件操作相关工具类
    /// </summary>
    public class FileUtil
    {
        /// <summary>
        /// 复制目录下的所有文件以及子目录下的所有文件(包含子目录)
        /// </summary>
        /// <param name="sourcePath">源文件夹</param>
        /// <param name="destinationPath">目标文件夹</param>
        /// <param name="isOverwrite">目标文件已存在是否覆盖</param>
        /// <returns>是否复制成功</returns>
        public static bool copyDirectory(String sourcePath, String destinationPath, bool isOverwrite = true)
        {
            bool ret = false;
            try
            {
                sourcePath = sourcePath.EndsWith(@"\") ? sourcePath : sourcePath + @"\";
                destinationPath = destinationPath.EndsWith(@"\") ? destinationPath : destinationPath + @"\";
                if (Directory.Exists(sourcePath))
                {
                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    foreach (String fls in Directory.GetFiles(sourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(destinationPath + flinfo.Name, isOverwrite);
                    }
                    foreach (String drs in Directory.GetDirectories(sourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (!copyDirectory(drs, destinationPath + drinfo.Name, isOverwrite))
                        {
                            ret = false;
                        }
                    }
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine(ex);
            }
            return ret;
        }

        public static string SanitizePath(string path)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char invalidChar in invalidChars)
            {
                path = path.Replace(invalidChar.ToString(), " ");
            }
            return path;
        }
    }
}
