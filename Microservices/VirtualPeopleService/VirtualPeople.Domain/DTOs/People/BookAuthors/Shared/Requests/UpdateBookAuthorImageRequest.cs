using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests
{
    public class UpdateBookAuthorImageRequest
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
