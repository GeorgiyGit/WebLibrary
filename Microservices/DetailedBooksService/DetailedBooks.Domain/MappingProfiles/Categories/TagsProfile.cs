using DetailedBooks.Domain.DTOs.TagDTOs.Responses;
using DetailedBooks.Domain.Entities.Categories;

namespace DetailedBooks.Domain.MappingProfiles.Categories
{
    public class TagsProfile:AutoMapper.Profile
    {
        public TagsProfile()
        {
            CreateMap<Tag, TagDTO>();
        }
    }
}
