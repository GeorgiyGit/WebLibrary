using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using MediatR;

namespace Categories.Application.TagTypes.Queries
{
    public class GetAllTagTypes : IRequest<ICollection<TagTypeDTO>>
    {
    }
}
