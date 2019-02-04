using System;

namespace EPAM.Task5._01_BackupSystem
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"{Environment.NewLine}Very Simple Backup System{Environment.NewLine}");
            Console.WriteLine("Enter folder path for watch or backup");
            try
            {
                BackupSystem.SourcePath = Console.ReadLine();
                if (BackupSystem.SourcePath[BackupSystem.SourcePath.Length - 1] == '\\')
                {
                    BackupSystem.SourcePath = BackupSystem.SourcePath.Remove(BackupSystem.SourcePath.Length - 1);
                }

                BackupSystem.BackupPath = BackupSystem.SourcePath.Insert(BackupSystem.SourcePath.Length, "Backup");
            }
            catch (IndexOutOfRangeException)
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
                        BackupSystem.Watch();
                        Main();
                        break;
                    }

                case "2":
                    {
                        BackupSystem.Recovery();
                        Main();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}