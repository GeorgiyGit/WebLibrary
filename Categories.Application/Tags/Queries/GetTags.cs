using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;

namespace Categories.Application.Tags.Queries
{
    public class GetTags : IRequest<ICollection<SimpleTagDTO>>
    {
        public string? FilterStr { get; set; }
        public string TypeId { get; set; }
        public bool IsDeletedAvailable { get; set; }
    }
}
