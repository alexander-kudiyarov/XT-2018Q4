using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public class UserDao : IUserDao
    {
        private static Dictionary<string, Award> awardList;
        private static string awardListPath = System.AppDomain.CurrentDomain.BaseDirectory + "ListOfAwards.bin";
        private static Dictionary<string, ProgramUser> programUserList;
        private static string programUserListPath = System.AppDomain.CurrentDomain.BaseDirectory + "ListOfProgramUsers.bin";
        private static Dictionary<int, User> userList;
        private static string userListPath = System.AppDomain.CurrentDomain.BaseDirectory + "ListOfUsers.bin";
        private static HashSet<KeyValuePair<int, string>> usersAndAwardsList = new HashSet<KeyValuePair<int, string>>();
        private static string usersAndAwardsListPath = System.AppDomain.CurrentDomain.BaseDirectory + "ListOfUsersAndAwards.bin";
        private TextInfo textInfo = new CultureInfo("us-US", false).TextInfo;

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

        public bool AddAward(Award award)
        {
            if (!awardList.ContainsKey(award.Title))
            {
                awardList.Add(award.Title, award);
                this.WriteToBinaryFile(awardListPath, awardList, false);
                return true;
            }

            return false;
        }

        public void AddAwardToUser(int id, Award award)
        {
            usersAndAwardsList.Add(new KeyValuePair<int, string>(id, award.Title));
            this.WriteToBinaryFile(usersAndAwardsListPath, usersAndAwardsList, false);
        }

        public void AddProgramUser(ProgramUser user)
        {
            if (!programUserList.ContainsKey(user.Name))
            {
                programUserList.Add(user.Name, user);
                this.WriteToBinaryFile(programUserListPath, programUserList, false);
            }
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

        public bool Authorization(string name, string password)
        {
            if (programUserList.ContainsKey(name.ToLower()))
            {
                if (programUserList[name.ToLower()].Password.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }

        public void EditProgramUser(string username, string newRole)
        {
            if (programUserList.ContainsKey(username) && !username.ToLower().Equals("admin"))
            {
                programUserList[username].Role = newRole;
                this.WriteToBinaryFile(programUserListPath, programUserList, false);
            }
        }

        public void EditUser(int id, string f_name, string l_name, string b_date)
        {
            if (userList.ContainsKey(id))
            {
                if (!string.IsNullOrWhiteSpace(f_name))
                {
                    userList[id].FirstName = f_name.ToLower();
                }

                if (!string.IsNullOrWhiteSpace(l_name))
                {
                    userList[id].LastName = l_name.ToLower();
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

        public IEnumerable<ProgramUser> GetAllProgramUsers()
        {
            this.LoadProgramUserList();
            return programUserList.Values;
        }

        public IEnumerable<User> GetAllUsers()
        {
            this.LoadUserList();
            this.LoadAwardList();
            return userList.Values;
        }

        public string GetProgramUserRole(string name)
        {
            if (programUserList.ContainsKey(name))
            {
                return programUserList[name].Role;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetUserAwards(int id)
        {
            StringBuilder temp = new StringBuilder();
            if (usersAndAwardsList.Count > 0)
            {
                temp.Append(" Awards: ");
                foreach (var title in usersAndAwardsList)
                {
                    temp.Append($"{this.textInfo.ToTitleCase(title.Value)}, ");
                }

                temp.Remove(temp.Length - 2, 2);
                return temp.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public void RemoveAward(string award)
        {
            foreach (var pair in usersAndAwardsList)
            {
                if (pair.Value.Equals(award))
                {
                    usersAndAwardsList.Remove(pair);
                    this.WriteToBinaryFile(usersAndAwardsListPath, usersAndAwardsList, false);
                    break;
                }
            }
        }

        public void RemoveProgramUser(string username)
        {
            if (programUserList.ContainsKey(username.ToLower()) && !username.ToLower().Equals("admin"))
            {
                programUserList.Remove(username.ToLower());
                this.WriteToBinaryFile(programUserListPath, programUserList, false);
            }
        }

        public void RemoveUser(int id)
        {
            if (userList.ContainsKey(id))
            {
                userList.Remove(id);
                this.WriteToBinaryFile(userListPath, userList, false);
            }
        }

        private void LoadAwardList()
        {
            if (File.Exists(awardListPath))
            {
                awardList = ReadFromBinaryFile<Dictionary<string, Award>>(awardListPath);
            }
            else
            {
                awardList = new Dictionary<string, Award>();
                this.WriteToBinaryFile(awardListPath, awardList, false);
            }
        }

        private void LoadProgramUserList()
        {
            if (File.Exists(programUserListPath))
            {
                programUserList = ReadFromBinaryFile<Dictionary<string, ProgramUser>>(programUserListPath);
            }
            else
            {
                programUserList = new Dictionary<string, ProgramUser>() { { "admin", new ProgramUser("admin", "password", "admin") } };
                this.WriteToBinaryFile(programUserListPath, programUserList, false);
            }
        }

        private void LoadUserList()
        {
            if (File.Exists(userListPath))
            {
                userList = ReadFromBinaryFile<Dictionary<int, User>>(userListPath);
            }
            else
            {
                userList = new Dictionary<int, User>();
                this.WriteToBinaryFile(userListPath, userList, false);
            }
        }

        private void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
    }
}