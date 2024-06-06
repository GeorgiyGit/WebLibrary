using DetailedBooks.Domain.DTOs.AuthorDTOs.Responses;
using DetailedBooks.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.MappingProfiles.Authors
{
    public class AuthorProfile:AutoMapper.Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();
        }
    }
}
