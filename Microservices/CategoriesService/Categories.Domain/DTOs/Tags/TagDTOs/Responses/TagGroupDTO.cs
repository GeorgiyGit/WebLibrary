using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;

namespace Categories.Domain.DTOs.Tags.TagDTOs.Responses
{
    public class TagGroupDTO
    {
        public TagTypeDTO Type { get; set; }
        public ICollection<SimpleTagDTO> Tags { get; set; } = new List<SimpleTagDTO>();
    }
}
