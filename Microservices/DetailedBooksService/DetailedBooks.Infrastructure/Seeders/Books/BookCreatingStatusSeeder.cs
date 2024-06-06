using DetailedBooks.Domain.Entities.Authors;
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
    internal class BookCreatingStatusSeeder : IEntityTypeConfiguration<BookChaptersCreatingStatus>
    {
        public void Configure(EntityTypeBuilder<BookChaptersCreatingStatus> builder)
        {
            var everyone = new BookChaptersCreatingStatus()
            {
                Id = BookChaptersCreatingStatuses.Everyone,
                Name = "Všetci používatelia"
            };
            
            var onlyTeams = new BookChaptersCreatingStatus()
            {
                Id = BookChaptersCreatingStatuses.OnlyTeams,
                Name = "Iba tímy"
            };

            var none = new BookChaptersCreatingStatus()
            {
                Id = BookChaptersCreatingStatuses.None,
                Name = "Nikto"
            };

            builder.HasData(everyone, onlyTeams, none);
        }
    }
}
