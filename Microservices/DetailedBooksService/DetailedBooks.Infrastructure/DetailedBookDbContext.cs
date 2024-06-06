using DetailedBooks.Domain.Entities.Authors;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Entities.Categories;
using DetailedBooks.Domain.Entities.Customers;
using DetailedBooks.Domain.Entities.Images;
using DetailedBooks.Domain.Interfaces;
using DetailedBooks.Infrastructure.Builders.Books;
using Microsoft.EntityFrameworkCore;

namespace DetailedBooks.Infrastructure
{
    public class DetailedBookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<BookRatingPointStatistic> BookRatingPointStatistics { get; set; }

        public DbSet<BookChaptersCreatingStatus> BookChaptersCreatingStatuses { get; set; }
        public DbSet<BookVisibilityStatus> BookVisibilityStatuses { get; set; }
        public DbSet<BookChaptersAccessibility> BookChaptersAccessibilities { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<MyImage> Images { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DetailedBookDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
        }
    }
}
