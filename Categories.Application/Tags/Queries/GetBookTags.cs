using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;

namespace Categories.Application.Tags.Queries
{
    public class GetBookTags : IRequest<ICollection<SimpleTagDTO>>
    {
        public int BookId { get; set; }
        public string TagTypeId { get; set; }
        public bool IsDeletedAvailable { get; set; }
    }
}
