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

        public bool AddAward(Award award)
        {
            return this.userDaoOb.AddAward(award);
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

        public void EditProgramUser(string username, string newRole)
        {
            this.userDaoOb.EditProgramUser(username, newRole);
        }

        public void EditUser(int id, string f_name, string l_name, string b_date)
        {
            this.userDaoOb.EditUser(id, f_name, l_name, b_date);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDaoOb.GetAllUsers();
        }

        public IEnumerable<ProgramUser> GetAllProgramUsers()
        {
            return this.userDaoOb.GetAllProgramUsers();
        }

        public string GetProgramUserRole(string name)
        {
            return this.userDaoOb.GetProgramUserRole(name);
        }

        public string GetUserAwards(int id)
        {
            return this.userDaoOb.GetUserAwards(id);
        }

        public void Remove(int id)
        {
            this.userDaoOb.RemoveUser(id);
        }

        public void RemoveAward(string award)
        {
            this.userDaoOb.RemoveAward(award);
        }

        public void RemoveProgramUser(string username)
        {
            this.userDaoOb.RemoveProgramUser(username);
        }
    }
}