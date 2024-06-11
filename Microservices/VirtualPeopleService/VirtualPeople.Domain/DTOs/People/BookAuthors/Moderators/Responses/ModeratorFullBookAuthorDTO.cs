using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses
{
    public class ModeratorFullBookAuthorDTO : FullBookAuthorDTO
    {
        public bool IsModerated { get; set; }

        public DateTime? DataLastDeleteTime { get; set; }
        public DateTime? DataLastEditTime { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
