﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public class UserDao : IUserDao
    {
        private static Dictionary<string, Award> awardList;
        private static string awardListPath = @"D:\AwardList.bin";
        private static Dictionary<int, User> userList;
        private static string userListPath = @"D:\UserList.bin";

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return (T)binaryFormatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
            catch (TypeInitializationException exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public void AddAward(Award award)
        {
                awardList.Add(award.Title, award);
                this.WriteToBinaryFile(awardListPath, awardList, false);
        }

        public void AddAwardToUser(int id, Award award)
        {
            userList[id].AwardsList.AddLast(award);
            this.WriteToBinaryFile(userListPath, userList, false);
        }

        public void AddUser(User user)
        {
            int lastId = userList.Any()
                ? userList.Keys.Max()
                : 0;

            user.Id = ++lastId;
            userList.Add(user.Id, user);
            this.WriteToBinaryFile(userListPath, userList, false);
        }

        public void CreateNewAwardList()
        {
            File.Delete(awardListPath);
        }

        public void CreateNewUserList()
        {
            File.Delete(userListPath);
        }

        public void EditUser(int id, string f_name, string l_name, string b_date)
        {
            if (userList.ContainsKey(id))
            {
                if (!string.IsNullOrWhiteSpace(f_name))
                {
                    userList[id].FirstName = f_name;
                }

                if (!string.IsNullOrWhiteSpace(l_name))
                {
                    userList[id].LastName = l_name;
                }

                if (!string.IsNullOrWhiteSpace(b_date))
                {
                    if (DateTime.TryParse(b_date, out DateTime temp))
                    {
                        userList[id].DateOfBirth = temp;
                    }
                }

                this.WriteToBinaryFile(userListPath, userList, false);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return userList.Values;
        }

        public void LoadAwardList()
        {
            if (File.Exists(awardListPath))
            {
                awardList = ReadFromBinaryFile<Dictionary<string, Award>>(awardListPath);
            }
            else
            {
                awardList = new Dictionary<string, Award>();
            }
        }

        public void LoadUserList()
        {
            if (File.Exists(userListPath))
            {
                userList = ReadFromBinaryFile<Dictionary<int, User>>(userListPath);
            }
            else
            {
                userList = new Dictionary<int, User>();
            }
        }

        public void Remove(int id)
        {
            userList.Remove(id);
            this.WriteToBinaryFile(userListPath, userList, false);
        }

        public void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
    }
}