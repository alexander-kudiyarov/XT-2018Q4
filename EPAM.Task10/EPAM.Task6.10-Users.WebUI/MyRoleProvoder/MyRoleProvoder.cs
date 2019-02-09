using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPAM.Task6._01_Users.BLL.Interfaces;
using EPAM.Task6._01_Users.Common;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._10_Users.WebUI.MyRoleProvoder
{
    public class MyRoleProvoder : RoleProvider
    {
        private IUserLogic userLogic = DependencyResolver.UserLogic;

        public override string[] GetRolesForUser(string username)
        {
            return new[] { this.userLogic.GetProgramUserRole(username) };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return this.userLogic.GetProgramUserRole(username) == roleName;
        }

        #region NotImplemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}