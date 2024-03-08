using DetailedBooks.Domain.DTOs.StatusDTOs.Responses;
using DetailedBooks.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.MappingProfiles.Books
{
    public class StatusesProfile:AutoMapper.Profile
    {
        public StatusesProfile()
        {
            CreateMap<BookChaptersCreatingStatus, ChaptersCreatingStatusDTO>();
            CreateMap<BookVisibilityStatus, VisibilityStatusDTO>();
        }
    }
}
