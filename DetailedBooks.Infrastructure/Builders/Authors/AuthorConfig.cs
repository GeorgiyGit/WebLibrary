using DetailedBooks.Domain.Entities.Authors;
using DetailedBooks.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Builders.Authors
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasOne(e => e.Image)
                   .WithOne(e => e.Author)
                   .HasForeignKey<Author>(e => e.ImageId)
                   .IsRequired(false);

            builder.HasMany(e => e.Books)
                   .WithOne(e => e.Author)
                   .HasForeignKey(e => e.AuthorId);
        }
    }
}
