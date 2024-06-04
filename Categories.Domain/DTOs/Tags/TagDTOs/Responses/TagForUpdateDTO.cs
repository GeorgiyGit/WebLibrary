using Categories.Domain.DTOs.TranslatedTextDTOs;

namespace Categories.Domain.DTOs.Tags.TagDTOs.Responses
{
    public class TagForUpdateDTO
    {
        public int Id { get; set; }
        public ICollection<TranslatedTextDTO> Names { get; set; }
    }
}
