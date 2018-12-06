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
            ////User s = db.Users.Find(Int32.Parse(username));

            //if (s != null)
            //{
            //    if (s.Role == "Admin")
            //    {
            //        return new string[] { "Admin" };
            //    }
            //    else if (s.Role == "Regional")
            //    {
            //        return new string[] { "Regional" };
            //    }
            //    else if (s.Role == "Manager")
            //    {
            //        return new string[] { "Manager" };
            //    }
            //    else if (s.Role == "SP2/SP3")
            //    {
            //        return new string[] { "SP2/SP3" };
            //    }
            //    else if (s.Role == "SP1")
            //    {
            //        return new string[] { "SP1" };
            //    }
            //}
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
