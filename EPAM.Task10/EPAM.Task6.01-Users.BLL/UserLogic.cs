using System.Collections.Generic;
using EPAM.Task6._01_Users.BLL.Interfaces;
using EPAM.Task6._01_Users.DAL;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDaoOb;

        public UserLogic(IUserDao userDao)
        {
            this.userDaoOb = userDao;
        }

        public void AddAward(Award award)
        {
            this.userDaoOb.AddAward(award);
        }

        public void AddAwardToUser(int id, Award award)
        {
            this.userDaoOb.AddAwardToUser(id, award);
        }

        public void AddProgramUser(ProgramUser user)
        {
            this.userDaoOb.AddProgramUser(user);
        }

        public void AddUser(User user)
        {
            this.userDaoOb.AddUser(user);
        }

        public bool Authorization(string name, string password)
        {
            return this.userDaoOb.Authorization(name, password);
        }

        public void EditUser(int id, string f_name, string l_name, string b_date)
        {
            this.userDaoOb.EditUser(id, f_name, l_name, b_date);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDaoOb.GetAll();
        }

        public void LoadAwardList()
        {
            this.userDaoOb.LoadAwardList();
        }

        public void LoadUserList()
        {
            this.userDaoOb.LoadUserList();
        }

        public void OverwriteAwardList()
        {
            this.userDaoOb.CreateNewAwardList();
        }

        public void OwerwriteUserList()
        {
            this.userDaoOb.CreateNewUserList();
        }

        public void Remove(int id)
        {
            this.userDaoOb.Remove(id);
        }

        public void RemoveAward(string award)
        {
            this.userDaoOb.RemoveAward(award);
        }

        public string GetProgramUserRole(string name)
        {
            return this.userDaoOb.GetProgramUserRole(name);
        }
    }
}