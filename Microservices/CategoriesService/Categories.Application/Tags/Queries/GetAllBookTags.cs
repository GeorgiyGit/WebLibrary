using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;

namespace Categories.Application.Tags.Queries
{
    public class GetAllBookTags : IRequest<ICollection<TagGroupDTO>>
    {
        public int BookId { get; set; }
        public bool IsDeletedAvailable { get; set; }
    }
}
