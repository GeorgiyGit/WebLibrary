using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Domain.Resources.Customers
{
    public struct UserRoles
    {
        public const string User = "User";
        public const string Moderator = "Moderator";
        public const string Admin = "Admin";

        public static List<string> GetAllRoles()
        {
            return new List<string>()
            {
                User,
                Moderator,
                Admin
            };
        }
    }
}
