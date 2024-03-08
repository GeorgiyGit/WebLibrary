using DetailedBooks.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Builders.Books
{
    internal class BookRatingConfig : IEntityTypeConfiguration<BookRating>
    {
        public void Configure(EntityTypeBuilder<BookRating> builder)
        {
            builder.HasOne(e => e.Customer)
                   .WithMany(e => e.BookRatings)
                   .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.Book)
                   .WithMany(e => e.Ratings)
                   .HasForeignKey(e => e.BookId);
        }
    }
}
