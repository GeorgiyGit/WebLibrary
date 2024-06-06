using Categories.Domain.DTOs.TranslatedTextDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Tags.Commands
{
    public class UpdateTag : IRequest
    {
        public int Id { get; set; }
        public ICollection<TranslatedTextDTO> Names { get; set; } = new List<TranslatedTextDTO>();
    }
}
