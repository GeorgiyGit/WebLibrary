using DetailedBooks.Application.Books.Events;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Resources.Constants;
using DetailedBooks.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DetailedBooks.Application.Books.EventHandler
{
    public class BookRatingChangedEventHandler : INotificationHandler<BookRatingChangedEvent>
    {
        private readonly DetailedBookDbContext _dbContext;
        public BookRatingChangedEventHandler(DetailedBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(BookRatingChangedEvent notification, CancellationToken cancellationToken)
        {
            var bookRating = await _dbContext.BookRatings.Where(e => e.Id == notification.BookRatingId && !e.IsDeleted)
                                                         .FirstOrDefaultAsync();

            var book = await _dbContext.Books.Where(e => e.Id == notification.BookId && !e.IsDeleted)
                                             .FirstOrDefaultAsync();



            ICollection<BookRatingPointStatistic> pointStatistics = await _dbContext.BookRatingPointStatistics.Where(e => e.BookId == notification.BookId)
                                                                                                              .OrderBy(e => e.Point)
                                                                                                              .ToListAsync();

            if (pointStatistics == null || pointStatistics.Count==0)
            {
                pointStatistics = await CreatePointStatistics(notification.BookId);
            }

            foreach (var pStatistic in pointStatistics)
            {
                var count = await _dbContext.BookRatings.CountAsync(e => e.BookId == notification.BookId && e.Point == pStatistic.Point);
                double percent = (double)book.RatingsCount / (double)count * 100d;

                pStatistic.Count = count;
                pStatistic.Percent = percent;
            }

            await _dbContext.SaveChangesAsync();
        }
        private async Task<ICollection<BookRatingPointStatistic>> CreatePointStatistics(int bookId)
        {
            for (int i = 1; i <= RatingConstants.TOTAL_POINTS; i++)
            {
                var pStatistic = new BookRatingPointStatistic()
                {
                    BookId = bookId,
                    Count = 0,
                    Percent = 0,
                    Point = i
                };
                await _dbContext.AddAsync(pStatistic);
            }
            await _dbContext.SaveChangesAsync();
            return await _dbContext.BookRatingPointStatistics.Where(e => e.BookId == bookId)
                                                             .OrderBy(e => e.Point)
                                                             .ToListAsync();
        }
    }
}
