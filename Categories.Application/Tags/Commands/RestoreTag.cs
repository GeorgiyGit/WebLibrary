using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Tags.Commands
{
    public class RestoreTag : IRequest
    {
        public int Id { get; set; }
    }
}
