using Categories.Domain.Resources.Tags;

namespace Categories.Domain.DTOs.Tags.TagDTOs.Requests
{
    public class GetTagsRequest
    {
        public string? FilterStr { get; set; } = "";
        public string TypeId { get; set; } = TagTypes.Tag;
    }
}
