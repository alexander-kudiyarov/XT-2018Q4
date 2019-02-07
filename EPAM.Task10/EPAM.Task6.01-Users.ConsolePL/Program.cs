using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EPAM.Task6._01_Users.BLL.Interfaces;
using EPAM.Task6._01_Users.Common;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.ConsolePL
{
    public class Program
    {
        public static void Main()
        {
            var userLogic = DependencyResolver.UserLogic;

            try
            {
                userLogic.LoadUserList();
            }
            catch (SerializationException exc)
            {
                userLogic.OwerwriteUserList();
                Console.WriteLine($"UserList was corrupted." +
                    $"{Environment.NewLine}{exc.Message}");
                Main();
            }

            try
            {
                userLogic.LoadAwardList();
            }
            catch (SerializationException exc)
            {
                userLogic.OverwriteAwardList();
                Console.WriteLine($"AwardList was corrupted." +
                    $"{Environment.NewLine}{exc.Message}");
                Main();
            }

            Console.WriteLine($"{Environment.NewLine}" +
                $"Enter:" +
                $"{Environment.NewLine}<add user>\tto add new user" +
                $"{Environment.NewLine}<edit user>\tto edit user" +
                $"{Environment.NewLine}<remove>\tto remove user" +
                $"{Environment.NewLine}<show>\t\tto show list of users and their awards" +
                $"{Environment.NewLine}<add award>\tto add awards for users" +
                $"{Environment.NewLine}<remove award>\tto remove awards" +
                $"{Environment.NewLine}<q>\t\tto quit the program" +
                $"{Environment.NewLine}");

            switch (Console.ReadLine().ToLower())
            {
                case "add user":
                    {
                        AddUser(userLogic);
                        goto default;
                    }

                case "edit":
                    {
                        EditUser(userLogic);
                        goto default;
                    }

                case "remove":
                    {
                        RemoveUser(userLogic);
                        goto default;
                    }

                case "show":
                    {
                        ShowUsers(userLogic);
                        goto default;
                    }

                case "add award":
                    {
                        AddAward(userLogic);
                        goto default;
                    }

                case "remove award":
                    {
                        RemoveAward(userLogic);
                        goto default;
                    }

                case "q":
                    {
                        break;
                    }

                default:
                    {
                        Main();
                        break;
                    }
            }
        }

        private static void AddAward(IUserLogic userLogic)
        {
            try
            {
                Console.WriteLine("Title:");
                string title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Title cannot be empty");
                    return;
                }

                var newAward = new Award
                {
                    Title = title,
                };
                try
                {
                    userLogic.AddAward(newAward);
                    Console.WriteLine("Enter ID of users to give them awards");
                    char[] div = { ',', ' ' };
                    string[] idList = Console.ReadLine().Split(div, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var id in idList)
                    {
                        userLogic.AddAwardToUser(Convert.ToInt32(id), newAward);
                    }
                }
                catch(ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (KeyNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void AddUser(IUserLogic userLogic)
        {
            Console.WriteLine("First Name:");
            string f_name = Console.ReadLine();
            if (string.IsNullOrEmpty(f_name))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Console.WriteLine("Last Name:");
            string l_name = Console.ReadLine();
            if (string.IsNullOrEmpty(l_name))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Console.WriteLine("Date of Birth:");
            try
            {
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                var newUser = new User
                {
                    FirstName = f_name,
                    LastName = l_name,
                    DateOfBirth = dateOfBirth,
                };
                userLogic.AddUser(newUser);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void EditUser(IUserLogic userLogic)
        {
            Console.WriteLine("Enter ID to change");
            if (int.TryParse(Console.ReadLine(), out int editId))
            {
                Console.WriteLine("Enter First Name");
                string editFirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string editLastName = Console.ReadLine();
                Console.WriteLine("Enter Birth Date");
                string editBirthDate = Console.ReadLine();
                userLogic.EditUser(editId, editFirstName, editLastName, editBirthDate);
            }
        }

        private static void RemoveUser(IUserLogic userLogic)
        {
            Console.WriteLine("Enter ID of users to give them awards");
            char[] div = { '.', ',', ' ' };
            string[] idList = Console.ReadLine().Split(div, StringSplitOptions.RemoveEmptyEntries);
            foreach (var id in idList)
            {
                userLogic.Remove(Convert.ToInt32(id));
            }
        }

        private static void ShowUsers(IUserLogic userLogic)
        {
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user.ToString());
            }
        }

        private static void RemoveAward(IUserLogic userLogic)
        {
            Console.WriteLine("Enter title of award to remove");
            string title = Console.ReadLine();

            userLogic.RemoveAward(title);
        }
    }
}