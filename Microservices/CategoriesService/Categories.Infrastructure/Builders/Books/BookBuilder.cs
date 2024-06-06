using Categories.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Categories.Infrastructure.Builders.Books
{
    internal class BookBuilder : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(e => e.Tags)
                   .WithMany(e => e.Books);
        }
    }
}
