using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Application.People.BookAuthors.Shared.Commands
{
    public class UpdateBookAuthorImage : IRequest
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
