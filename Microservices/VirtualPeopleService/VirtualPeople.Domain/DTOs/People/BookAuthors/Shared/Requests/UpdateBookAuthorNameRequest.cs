using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests
{
    public class UpdateBookAuthorNameRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
