using Categories.Domain.DTOs.TranslatedTextDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Tags.Commands
{
    public class AddTag : IRequest<int>
    {
        public ICollection<TranslatedTextDTO> Names { get; set; } = new List<TranslatedTextDTO>();
        public string TypeId { get; set; }
    }
}
