/*************************************************************************************
 *
 * 文 件 名:   FileUtil.cs
 * 描    述:   文件工具类
 * 
 * 版    本：  V1.0
 * 创 建 者：  zhangmuyu 
 * 创建时间：  2022/02/12
 * ======================================
 * 历史更新记录
 * 版本：          修改时间：         修改人：
 * 修改内容：
 * ======================================
*************************************************************************************/
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
        public static bool copyDirectory(String sourcePath, String destinationPath, bool isOverwrite=true)
        {
            bool ret = false;
            try
            {
                sourcePath = sourcePath.EndsWith(@"\") ? sourcePath : sourcePath + @"\";
                destinationPath = destinationPath.EndsWith(@"\") ? destinationPath : destinationPath + @"\";
                //源文件夹是否存在
                if (Directory.Exists(sourcePath))
                {
                    //目标文件夹是否存在，不存在则创建
                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    //将源文件夹下的文件复制过去
                    foreach (String fls in Directory.GetFiles(sourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(destinationPath + flinfo.Name, isOverwrite);
                    }
                    //复制源文件夹下的子文件夹内容
                    foreach (String drs in Directory.GetDirectories(sourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (!copyDirectory(drs, destinationPath + drinfo.Name, isOverwrite))
                        {
                            ret = false;
                        }
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine(ex);
            }
            return ret;
        }
    }
}
