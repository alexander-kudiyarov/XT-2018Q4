using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM.Task5._01_BackupSystem
{
    public class Program
    {
        private static string sourcePath;
        private static string backupPath;
        private static string dateFormat = "yyyy-MM-dd HH-mm-ss";

        public static void Main()
        {
            Console.WriteLine($"{Environment.NewLine}Very Simple Backup System{Environment.NewLine}");
            Console.WriteLine("Enter folder path for watch or backup");
            try
            {
                sourcePath = Console.ReadLine();
                if (sourcePath[sourcePath.Length - 1] == '\\')
                {
                    sourcePath = sourcePath.Remove(sourcePath.Length - 1);
                }

                backupPath = sourcePath.Insert(sourcePath.Length, "Backup");
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine("Incorrect folder path");
                return;
            }

            Console.WriteLine($"{Environment.NewLine}Select mode:" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}Enter <1> for Watch mode" +
                $"{Environment.NewLine}Enter <2> for Recovery mode" +
                $"{Environment.NewLine}Enter any other key for exit" +
                $"{Environment.NewLine}");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Watch();
                        Main();
                        break;
                    }

                case "2":
                    {
                        Recovery();
                        Main();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private static void Watch()
        {
            Console.WriteLine($"Watching started{Environment.NewLine}");
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            if (!sourceDirectory.Exists)
            {
                Directory.CreateDirectory(sourcePath);
            }

            foreach (string filePath in Directory.GetFiles(sourcePath, "*.txt", SearchOption.AllDirectories))
            {
                watchDirectory(filePath);
            }

            FileSystemWatcher watcher = createWatcher();

            configureWatcher(watcher);

            Console.WriteLine($"Press <q> to stop watching{Environment.NewLine}");
            while (Console.Read() != 'q')
            {
            }

            Console.WriteLine($"Watching stopped{Environment.NewLine}");
            Console.ReadLine();
        }

        private static void configureWatcher(FileSystemWatcher watcher)
        {
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Renamed += new RenamedEventHandler(OnRename);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);
        }

        private static FileSystemWatcher createWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(sourcePath, "*.txt");
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.InternalBufferSize = 10485760;
            return watcher;
        }

        private static void watchDirectory(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            Directory.CreateDirectory(filePath.Replace(sourcePath, backupPath));
            File.Copy(filePath, filePath.Insert(filePath.Length, $@"\{fi.LastWriteTime.ToString(dateFormat)}").Replace(sourcePath, backupPath), true);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            while (IsFileLocked(fileInfo))
            {
                Thread.Sleep(1);
            }

            File.Copy(e.FullPath, e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}").Replace(sourcePath, backupPath), true);
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Directory.CreateDirectory(e.FullPath.Replace(sourcePath, backupPath));
            OnChanged(source, e);
        }

        private static void OnRename(object source, RenamedEventArgs namingEvent)
        {
            OnCreated(source, namingEvent);
            File.Create(namingEvent.OldFullPath.Insert(namingEvent.OldFullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(sourcePath, backupPath));
        }

        private static void OnDelete(object source, FileSystemEventArgs e)
        {
            File.Create(e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(sourcePath, backupPath));
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

        private static void Recovery()
        {
            Console.WriteLine($"Enter date and time of backup ('dd-MM-yyyy hh:mm:ss' for example){Environment.NewLine}");
            DateTime point = DateTime.Parse(Console.ReadLine());
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            if (sourceDirectory.Exists)
            {
                Directory.Delete(sourcePath, true);
            }

            foreach (string path in Directory.GetDirectories(backupPath, "*.txt", SearchOption.AllDirectories))
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
                            string filePath = versions[i].Remove(versions[i].LastIndexOf('\\')).Replace(backupPath, sourcePath);
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
    }
}
