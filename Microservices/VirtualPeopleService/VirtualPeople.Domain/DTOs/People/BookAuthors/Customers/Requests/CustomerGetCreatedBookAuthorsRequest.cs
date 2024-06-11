using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Users.Requests;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Requests
{
    public class CustomerGetCreatedBookAuthorsRequest : UserGetBookAuthorsRequest
    {
        public bool IsModeratedAvailable { get; set; }
    }
}
