using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo.Models;
using Duser;

namespace Repo.Factories
{
    public class FacUsers : AutoFac<Users>
    {
        public List<UsersRoles> GetAllUsersRoles()
        {
            string SQL = "SELECT Users.ID, Username, Firstname, Lastname, Email, Image, Users.Role, Roles.RoleName FROM Users INNER JOIN Roles ON Users.Role = Roles.ID";
            return ExecuteSQL<UsersRoles>(SQL);
        }

        public UsersRoles GetUserRole(int ID)
        {
            string SQL = "SELECT Users.ID, Username, Firstname, Lastname, Email, Image, Users.Role, Roles.RoleName FROM Users INNER JOIN Roles ON Users.Role = Roles.ID WHERE Users.ID =" + ID;
            return ExecuteSQL<UsersRoles>(SQL)[0];
        }
    }
}
