using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses
{
    public class CustomerFullBookAuthorDTO : FullBookAuthorDTO
    {
        public bool IsModerated { get; set; }
    }
}
