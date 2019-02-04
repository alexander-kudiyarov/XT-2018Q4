using System;
using System.IO;
using System.Threading;

namespace EPAM.Task5._01_BackupSystem
{
    public class BackupSystem
    {
        private static string dateFormat = "yyyy-MM-dd HH-mm-ss";

        public static string BackupPath { get; set; }

        public static string SourcePath { get; set; }

        public static void Recovery()
        {
            Console.WriteLine($"Enter date and time of backup ('dd-MM-yyyy hh:mm:ss' for example){Environment.NewLine}");
            DateTime point = DateTime.Parse(Console.ReadLine());
            DirectoryInfo sourceDirectory = new DirectoryInfo(SourcePath);
            if (sourceDirectory.Exists)
            {
                Directory.Delete(SourcePath, true);
            }

            foreach (string path in Directory.GetDirectories(BackupPath, "*.txt", SearchOption.AllDirectories))
            {
                string[] versions = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                for (int i = versions.Length - 1; i >= 0; i--)
                {
                    if (versions[i].Substring(versions[i].LastIndexOf('-')) == @"-deleted")
                    {
                        continue;
                    }
                    else
                    {
                        DateTime ver = DateTime.ParseExact(versions[i].Substring(versions[i].LastIndexOf('\\') + 1), dateFormat, null);
                        if (ver <= point)
                        {
                            string filePath = versions[i].Remove(versions[i].LastIndexOf('\\')).Replace(BackupPath, SourcePath);
                            string folderPath = filePath.Remove(filePath.LastIndexOf('\\'));
                            Directory.CreateDirectory(folderPath);
                            File.Copy(versions[i], filePath, true);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Backup successful");
            return;
        }

        public static void Watch()
        {
            Console.WriteLine($"Watching started{Environment.NewLine}");
            DirectoryInfo sourceDirectory = new DirectoryInfo(SourcePath);
            if (!sourceDirectory.Exists)
            {
                Directory.CreateDirectory(SourcePath);
            }

            foreach (string filePath in Directory.GetFiles(SourcePath, "*.txt", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(filePath);
                Directory.CreateDirectory(filePath.Replace(SourcePath, BackupPath));
                File.Copy(filePath, filePath.Insert(filePath.Length, $@"\{fi.LastWriteTime.ToString(dateFormat)}").Replace(SourcePath, BackupPath), true);
            }

            FileSystemWatcher watcher = new FileSystemWatcher(SourcePath, "*.txt");
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.InternalBufferSize = 10485760;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Renamed += new RenamedEventHandler(OnRename);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);

            Console.WriteLine($"Press <q> to stop watching{Environment.NewLine}");
            while (Console.Read() != 'q')
            {
            }

            Console.WriteLine($"Watching stopped{Environment.NewLine}");
            Console.ReadLine();
        }

        private static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return false;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            while (IsFileLocked(fileInfo))
            {
                Thread.Sleep(1);
            }

            File.Copy(e.FullPath, e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}").Replace(SourcePath, BackupPath), true);
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Directory.CreateDirectory(e.FullPath.Replace(SourcePath, BackupPath));
            OnChanged(source, e);
        }

        private static void OnDelete(object source, FileSystemEventArgs e)
        {
            File.Create(e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(SourcePath, BackupPath));
        }

        private static void OnRename(object source, RenamedEventArgs e)
        {
            OnCreated(source, e);
            File.Create(e.OldFullPath.Insert(e.OldFullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(SourcePath, BackupPath));
        }
    }
}