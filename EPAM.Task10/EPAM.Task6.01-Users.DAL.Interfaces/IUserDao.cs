using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public interface IUserDao
    {
        void AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddProgramUser(ProgramUser user);

        void AddUser(User user);

        bool Authorization(string name, string password);

        void CreateNewAwardList();

        void CreateNewUserList();

        void EditUser(int id, string f_name, string l_name, string b_date);

        IEnumerable<User> GetAll();

        void LoadAwardList();

        void LoadUserList();

        void Remove(int id);

        void RemoveAward(string award);

        string GetProgramUserRole(string name);
    }
}