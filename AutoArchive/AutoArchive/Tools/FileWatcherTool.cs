using System;
using System.IO;

namespace AutoArchive.Tools
{
    public class FileWatcherTool
    {
        public static FileSystemWatcher startWatch(String path, Action<object, FileSystemEventArgs> onChange,String filter= "*.*")
        {
            if (path == null)
            {
                return null;
            }
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                                           | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName
                                             | NotifyFilters.DirectoryName;
            //文件类型，支持通配符，“*.txt”只监视文本文件
            fileSystemWatcher.Filter = filter;
            // 监控子目录
            fileSystemWatcher.IncludeSubdirectories = true;  
            fileSystemWatcher.Changed += new FileSystemEventHandler(onChange);
            //表示当前的路径正式开始被监控，一旦监控的路径出现变更，FileSystemWatcher 中的指定事件将会被触发。
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.EndInit();
            return fileSystemWatcher;
        }
    }
}
