using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.BLL.Interfaces
{
    public interface IUserLogic
    {
        bool AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddProgramUser(ProgramUser user);

        void AddUser(User user);

        bool Authorization(string name, string password);

        void EditProgramUser(string username, string newRole);

        void EditUser(int id, string f_name, string l_name, string b_date);

        IEnumerable<User> GetAll();

        IEnumerable<ProgramUser> GetAllProgramUsers();

        string GetProgramUserRole(string name);

        string GetUserAwards(int id);

        void Remove(int id);

        void RemoveAward(string award);

        void RemoveProgramUser(string username);
    }
}