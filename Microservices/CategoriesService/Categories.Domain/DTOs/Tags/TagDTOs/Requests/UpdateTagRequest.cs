using Categories.Domain.DTOs.TranslatedTextDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Domain.DTOs.Tags.TagDTOs.Requests
{
    public class UpdateTagRequest
    {
        public int Id { get; set; }
        public ICollection<TranslatedTextDTO> Names { get; set; } = new List<TranslatedTextDTO>();
    }
}
