using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Users.Requests;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Requests
{
    public class ModeratorGetBookAuthorsRequest : UserGetBookAuthorsRequest
    {
        public bool IsDeletedAvailable { get; set; }
        public bool IsModeratedAvailable { get; set; }
    }
}
