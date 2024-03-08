using DetailedBooks.Domain.DTOs.BookDTOs.Responses;
using DetailedBooks.Domain.Entities.Books;

namespace DetailedBooks.Domain.MappingProfiles.Books
{
    public class BooksProfile:AutoMapper.Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, FullBookDTO>();
        }
    }
}
