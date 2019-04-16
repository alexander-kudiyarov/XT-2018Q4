﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_Common;

namespace WebUI.MyRoleProvider
{
    public class MyRoleProvider : RoleProvider
    {
        private IForumLogic forumLogic = DependencyResolver.ForumLogic;

        public override string[] GetRolesForUser(string username)
        {
            return this.forumLogic.GetUserRoles(username);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            foreach(var role in forumLogic.GetUserRoles(username))
            {
                if (role.Equals(roleName))
                {
                    return true;
                }
            }

            return false;
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