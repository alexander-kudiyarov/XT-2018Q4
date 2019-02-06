using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public interface IUserDao
    {
        void AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddUser(User user);

        void CreateNewAwardList();

        void CreateNewUserList();

        IEnumerable<User> GetAll();

        void LoadAwardList();

        void LoadUserList();

        void Remove(int id);
    }
}