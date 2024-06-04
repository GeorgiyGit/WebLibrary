
namespace Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses
{
    public class TagTypeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool IsCompraced { get; set; }
        public bool IsCancelable { get; set; }
    }
}
