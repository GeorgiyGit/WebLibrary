using DetailedBooks.Domain.Entities.Authors;
using DetailedBooks.Domain.Entities.Categories;
using DetailedBooks.Domain.Entities.Customers;
using DetailedBooks.Domain.Entities.Images;
using DetailedBooks.Domain.Entities.Shared;

namespace DetailedBooks.Domain.Entities.Books
{
    public class Book: Monitoring
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public MyImage Image { get; set; }
        public string ImageId { get; set; }

        public int MaxChaptersCount { get; set; }
        public int TotalChaptersCount { get; set; }

        public int ChapterCollectionsCount { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public Customer Owner { get; set; }
        public string OwnerId { get; set; }

        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

        public int? ChatId { get; set; }

        public ICollection<BookRating> Ratings { get; set; } = new HashSet<BookRating>();
        public int RatingsCount { get; set; }
        public double TotalRating { get; set; }

        public ICollection<BookRatingPointStatistic> PointsStatistic { get; set; } = new HashSet<BookRatingPointStatistic>();
    
        public BookCreatingStatus CreatingStatus { get; set; }
        public string CreatingStatusId { get; set; }

        public BookVisibilityStatus VisibilityStatus { get; set; }
        public string VisibilityStatusId { get; set; }


        public bool IsRatingClosed { get; set; }
    }
}
