using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Resources.BookStatuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Seeders.Books
{
    internal class BookChaptersAccessibilitySeeder : IEntityTypeConfiguration<BookChaptersAccessibility>
    {
        public void Configure(EntityTypeBuilder<BookChaptersAccessibility> builder)
        {
            var everyone = new BookChaptersAccessibility()
            {
                Id = BookChaptersAccessibilities.Everyone,
                Name = "Všetci používatelia",
                Description = "Všetci používatelia môžu interagovať s obsahom"
            };

            var copyrightBan = new BookChaptersAccessibility()
            {
                Id = BookChaptersAccessibilities.CopyrightBan,
                Name = "Autorské práva",
                Description = "Kvôli problémom s autorskými právami bola správa stránky nútená dočasne zablokovať tento zdroj"
            };

            builder.HasData(everyone, copyrightBan);
        }
    }
}
