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
    internal class BookRatingPointStatisticConfig : IEntityTypeConfiguration<BookRatingPointStatistic>
    {
        public void Configure(EntityTypeBuilder<BookRatingPointStatistic> builder)
        {
            builder.HasOne(e => e.Book)
                   .WithMany(e => e.PointsStatistic)
                   .HasForeignKey(e => e.BookId);
        }
    }
}
