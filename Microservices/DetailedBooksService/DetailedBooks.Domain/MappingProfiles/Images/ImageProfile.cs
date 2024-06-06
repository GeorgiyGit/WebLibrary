using DetailedBooks.Domain.DTOs.ImageDTOs;
using DetailedBooks.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.MappingProfiles.Images
{
    public class ImageProfile : AutoMapper.Profile
    {
        public ImageProfile()
        {
            CreateMap<MyImage, ImageDTO>();
        }
    }
}
