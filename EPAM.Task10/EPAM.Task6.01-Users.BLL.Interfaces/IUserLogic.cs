using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddProgramUser(ProgramUser user);

        void AddUser(User user);

        bool Authorization(string name, string password);

        void EditUser(int id, string f_name, string l_name, string b_date);

        IEnumerable<User> GetAll();

        void LoadAwardList();

        void LoadUserList();

        void OverwriteAwardList();

        void OwerwriteUserList();

        void Remove(int id);

        void RemoveAward(string award);

        string GetProgramUserRole(string name);
    }
}