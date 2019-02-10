using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public interface IUserDao
    {
        bool AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddProgramUser(ProgramUser user);

        void AddUser(User user);

        bool Authorization(string name, string password);

        void EditUser(int id, string f_name, string l_name, string b_date);

        void EditProgramUser(string username, string newRole);

        IEnumerable<User> GetAllUsers();

        IEnumerable<ProgramUser> GetAllProgramUsers();

        void RemoveUser(int id);

        void RemoveAward(string award);

        void RemoveProgramUser(string username);

        string GetProgramUserRole(string name);
    }
}