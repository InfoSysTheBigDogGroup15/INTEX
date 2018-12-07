using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INTEX.Models;
using INTEX.DAL;
using System.Web.Security;

namespace INTEX.App_Start
{
    public class IndexRoleProvider : RoleProvider
    {
        private NorthwestContext db = new NorthwestContext();
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
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

        public override string[] GetRolesForUser(string username)
        {
            string[] role = new string[] { };
            UserAuth s = db.UserAuths.Find(Int32.Parse(username));

            if (s != null)
            {
                if (s.role == "LabTech")
                {
                    return new string[] { "LabTech" };
                }
                else if (s.role == "Sales")
                {
                    return new string[] { "Sales" };
                }
                else if (s.role == "Client")
                {
                    return new string[] { "CLient" };
                }
                else if (s.role == "Admin")
                {
                    return new string[] { "Admin" };
                }
            }
            return new string[] { "" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}
