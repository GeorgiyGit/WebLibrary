using DetailedBooks.Domain.DTOs.BookDTOs.Responses;
using MediatR;

namespace DetailedBooks.Application.Books.Queries
{
    public class GetFullBookById : IRequest<FullBookDTO>
    {
        public int Id { get; set; }
    }
}
