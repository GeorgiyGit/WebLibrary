using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses
{
    public class FullBookAuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCount { get; set; }
        public DateTime DataCreationTime { get; set; }
    }
}
