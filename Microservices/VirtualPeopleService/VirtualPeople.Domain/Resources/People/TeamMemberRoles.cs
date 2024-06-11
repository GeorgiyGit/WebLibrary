using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.Resources.People
{
    public class TeamMemberRoles
    {
        public const string Member = "Member";
        public const string Moderator = "Moderator";
        public const string Admin = "Admin";

        public static List<string> GetAll()
        {
            return new List<string>()
            {
                Member,
                Moderator,
                Admin
            };
        }
    }
}
