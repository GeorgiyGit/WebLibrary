using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.Entities.People;

namespace VirtualPeople.Application.MappingProfiles.People
{
    public class BookAuthorMappingProfiles : AutoMapper.Profile
    {
        public BookAuthorMappingProfiles()
        {
            CreateMap<BookAuthor, SimpleBookAuthorDTO>();
            CreateMap<BookAuthor, ModeratorSimpleBookAuthorDTO>();
            CreateMap<BookAuthor, CustomerSimpleBookAuthorDTO>();

            CreateMap<BookAuthor, FullBookAuthorDTO>();
            CreateMap<BookAuthor, ModeratorFullBookAuthorDTO>();
            CreateMap<BookAuthor, CustomerFullBookAuthorDTO>();
        }
    }
}
