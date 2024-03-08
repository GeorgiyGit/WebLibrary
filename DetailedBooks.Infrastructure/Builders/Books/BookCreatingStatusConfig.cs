﻿using DetailedBooks.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Builders.Books
{
    internal class BookCreatingStatusConfig : IEntityTypeConfiguration<BookChaptersCreatingStatus>
    {
        public void Configure(EntityTypeBuilder<BookChaptersCreatingStatus> builder)
        {
            builder.HasMany(e => e.Books)
                   .WithOne(e => e.ChaptersCreatingStatus)
                   .HasForeignKey(e => e.ChaptersCreatingStatusId);
        }
    }
}
