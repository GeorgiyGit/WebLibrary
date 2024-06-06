
namespace DetailedBooks.Domain.Entities.Books
{
    public class BookRatingPointStatistic
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public int Count { get; set; }
        public double Percent { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
