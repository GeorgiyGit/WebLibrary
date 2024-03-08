using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DetailedBooks.Domain.Entities.Books;

namespace DetailedBooks.Infrastructure.Builders.Books
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(e => e.Image)
                   .WithOne(e => e.Book)
                   .HasForeignKey<Book>(e => e.ImageId);

            builder.HasOne(e => e.Author)
                   .WithMany(e => e.Books)
                   .HasForeignKey(e => e.AuthorId);

            builder.HasOne(e => e.Owner)
                   .WithMany(e => e.CreatedBooks)
                   .HasForeignKey(e => e.OwnerId);

            builder.HasMany(e => e.Tags)
                   .WithMany(e => e.Books);

            builder.HasMany(e => e.Ratings)
                   .WithOne(e => e.Book)
                   .HasForeignKey(e => e.BookId);

            builder.HasMany(e => e.PointsStatistic)
                   .WithOne(e => e.Book)
                   .HasForeignKey(e => e.BookId);

            builder.HasOne(e => e.CreatingStatus)
                   .WithMany(e => e.Books)
                   .HasForeignKey(e => e.CreatingStatusId);

            builder.HasOne(e => e.VisibilityStatus)
                   .WithMany(e => e.Books)
                   .HasForeignKey(e => e.VisibilityStatusId);
        }
    }
}
