using DetailedBooks.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Builders.Books
{
    internal class BookChaptersAccessibilityConfig : IEntityTypeConfiguration<BookChaptersAccessibility>
    {
        public void Configure(EntityTypeBuilder<BookChaptersAccessibility> builder)
        {
            builder.HasMany(e => e.Books)
                   .WithOne(e => e.ChaptersAccessibility)
                   .HasForeignKey(e => e.ChaptersAccessibilityId);
        }
    }
}
