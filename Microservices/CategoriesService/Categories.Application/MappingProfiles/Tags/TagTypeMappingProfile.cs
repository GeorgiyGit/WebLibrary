using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Entities.Tags;

namespace Categories.Application.MappingProfiles.Tags
{
    public class TagTypeMappingProfile : AutoMapper.Profile
    {
        public TagTypeMappingProfile()
        {
            CreateMap<TagType, TagTypeDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.Ignore());
        }
    }
}
