using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;

namespace Categories.Application.Tags.Queries
{
    public class GetAllCompracedTags : IRequest<ICollection<TagGroupDTO>>
    {
        public bool IsDeletedAvailable { get; set; }
    }
}
