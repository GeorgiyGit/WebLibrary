using AutoMapper;
using DetailedBooks.Application.Books.Queries;
using DetailedBooks.Domain.DTOs.BookDTOs.Responses;
using DetailedBooks.Domain.Exceptions;
using DetailedBooks.Domain.Resources.Localization.Errors;
using DetailedBooks.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Net;

namespace DetailedBooks.Application.Books.QueryHandlers
{
    public class GetFullBookByIdHandler : IRequestHandler<GetFullBookById, FullBookDTO>
    {
        private readonly DetailedBookDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly IMapper _mapper;
        public GetFullBookByIdHandler(DetailedBookDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<FullBookDTO> Handle(GetFullBookById request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(e => e.Id == request.Id && !e.IsDeleted)
                                       .Include(e => e.Image)
                                       .Include(e => e.Owner)
                                       .Include(e => e.Author)
                                       .Include(e => e.ChaptersCreatingStatus)
                                       .Include(e => e.VisibilityStatus)
                                       .Include(e => e.ChaptersAccessibility)
                                       .Include(e => e.Tags)
                                       .FirstOrDefaultAsync();

            if (book == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookNotFound], HttpStatusCode.NotFound);

            return _mapper.Map<FullBookDTO>(book);
        }
    }
}
