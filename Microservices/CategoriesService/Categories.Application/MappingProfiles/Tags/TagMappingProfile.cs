using Categories.Application.Tags.Commands;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.Entities.Tags;

namespace Categories.Application.MappingProfiles.Tags
{
    public class TagMappingProfile : AutoMapper.Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Tag, SimpleTagDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.Ignore());

            CreateMap<Tag, TagForUpdateDTO>();
        }
    }
}
