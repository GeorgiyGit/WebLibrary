using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Users.Requests
{
    public class UserGetBookAuthorsRequest
    {
        public string? FilterStr { get; set; } = "";
        public PageParameters PageParameters { get; set; }
    }
}
