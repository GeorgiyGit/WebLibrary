using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.Entities.Books;
using VirtualPeople.Domain.Entities.People;

namespace VirtualPeople.Infrastructure.Builders.People
{
    internal class BookAuthorBuilder : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasIndex(e => new { e.BookCount })
                   .IsDescending(true);
        }
    }
}
