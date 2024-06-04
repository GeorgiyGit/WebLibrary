using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;

namespace Categories.Application.Tags.Queries
{
    public class GetTagForUpdate : IRequest<TagForUpdateDTO>
    {
        public int Id { get; set; }
        public bool IsDeletedAvailable { get; set; }
    }
}
