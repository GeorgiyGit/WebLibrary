using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using MediatR;

namespace Categories.Application.TagTypes.Queries
{
    public class GetTagType : IRequest<TagTypeDTO>
    {
        public string Id { get; set; }
    }
}
