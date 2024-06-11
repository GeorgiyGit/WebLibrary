using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.Entities.Books;

namespace VirtualPeople.Infrastructure.Builders.Books
{
    internal class TeamBookBuilder : IEntityTypeConfiguration<TeamBook>
    {
        public void Configure(EntityTypeBuilder<TeamBook> builder)
        {
            builder.HasMany(e => e.InPlansTeams)
                   .WithMany(e => e.InPlansBooks);

            builder.HasMany(e => e.InProcessTeams)
                   .WithMany(e => e.InPlansBooks);

            builder.HasMany(e => e.CanceledTeams)
                   .WithMany(e => e.CanceledBooks);
        }
    }
}
