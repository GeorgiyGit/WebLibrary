using DetailedBooks.Domain.Entities.Authors;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Resources.BookStatuses;
using DetailedBooks.Infrastructure.Builders.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Infrastructure.Seeders.Books
{
    internal class BookVisibilityStatusSeeder : IEntityTypeConfiguration<BookVisibilityStatus>
    {
        public void Configure(EntityTypeBuilder<BookVisibilityStatus> builder)
        {
            var everyone = new BookVisibilityStatus()
            {
                Id = BookVisibilityStatuses.Everyone,
                Name = "Všetci používatelia"
            };

            var onlyModerators = new BookVisibilityStatus()
            {
                Id = BookVisibilityStatuses.OnlyModerators,
                Name = "Iba moderátori"
            };

            var onlyAdmins = new BookVisibilityStatus()
            {
                Id = BookVisibilityStatuses.OnlyAdmins,
                Name = "Iba správcovia"
            };

            builder.HasData(everyone, onlyModerators, onlyAdmins);
        }
    }
}
