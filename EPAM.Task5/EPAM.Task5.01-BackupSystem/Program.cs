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
            Console.WriteLine($"Very Simple Backup System" +
                $"{Environment.NewLine}" +
                $"{Environment.NewLine}Select mode:" +
                $"{Environment.NewLine}Enter <1> for Watch mode" +
                $"{Environment.NewLine}Enter <2> for Recovery mode" +
                $"{Environment.NewLine}");
            Console.WriteLine();
            Console.WriteLine("Enter folder path fot watch or backup");
            sourcePath = Console.ReadLine();
            if (sourcePath[sourcePath.Length - 1] == '\\')
            {
                sourcePath = sourcePath.Remove(sourcePath.Length - 1);
            }

            Console.WriteLine(sourcePath);
            backupPath = sourcePath.Insert(sourcePath.Length, "Backup");
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
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            if (!sourceDirectory.Exists)
            {
                Directory.CreateDirectory(sourcePath);
            }

            foreach (string filePath in Directory.GetFiles(sourcePath, "*.txt", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(filePath);
                Directory.CreateDirectory(filePath.Replace(sourcePath, backupPath));
                File.Copy(filePath, filePath.Insert(filePath.Length, $@"\{fi.LastWriteTime.ToString(dateFormat)}").Replace(sourcePath, backupPath), true);
            }

            FileSystemWatcher watcher = new FileSystemWatcher(sourcePath, "*.txt");
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.InternalBufferSize = 655360;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Renamed += new RenamedEventHandler(OnRename);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);

            Console.WriteLine(@"Press 'q' to quit the sample.");
            while (Console.Read() != 'q')
            {
            }

            Console.WriteLine("Watching stopped");
            return;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("OnChanged");
            File.Copy(e.FullPath, e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}").Replace(sourcePath, backupPath), true);
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("OnCreated");
            Directory.CreateDirectory(e.FullPath.Replace(sourcePath, backupPath));
            OnChanged(source, e);
            Thread.Sleep(3);
        }

        private static void OnRename(object source, RenamedEventArgs e)
        {
            OnCreated(source, e);
            File.Create(e.OldFullPath.Insert(e.OldFullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(sourcePath, backupPath));
        }

        private static void OnDelete(object source, FileSystemEventArgs e)
        {
            File.Create(e.FullPath.Insert(e.FullPath.Length, $@"\{DateTime.Now.ToString(dateFormat)}-deleted").Replace(sourcePath, backupPath));
        }

        private static void Recovery()
        {
            Console.WriteLine("Enter date and time of backup ('dd-MM-yyyy hh:mm:ss' for example)");
            DateTime point = DateTime.ParseExact(Console.ReadLine(), dateFormat, null);
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
                        break;
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

            Console.WriteLine("Backup successful");
            return;
        }
    }
}