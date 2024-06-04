using Categories.Domain.DTOs.TranslatedTextDTOs;

namespace Categories.Domain.DTOs.Tags.TagDTOs.Requests
{
    public class AddTagRequest
    {
        public ICollection<TranslatedTextDTO> Names { get; set; } = new List<TranslatedTextDTO>();
        public string TypeId { get; set; }
    }
}
