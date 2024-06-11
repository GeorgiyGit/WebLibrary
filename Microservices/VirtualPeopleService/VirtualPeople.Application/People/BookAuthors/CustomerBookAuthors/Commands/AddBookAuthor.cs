﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Commands
{
    public class AddBookAuthor : IRequest<int>
    {
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
