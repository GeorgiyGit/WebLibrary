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
    internal class TranslationTeamBuilder : IEntityTypeConfiguration<TranslationTeam>
    {
        public void Configure(EntityTypeBuilder<TranslationTeam> builder)
        {
            builder.HasMany(e => e.InPlansBooks)
                   .WithMany(e => e.InPlansTeams);

            builder.HasMany(e => e.InProcessBooks)
                   .WithMany(e => e.InProcessTeams);

            builder.HasMany(e => e.CanceledBooks)
                   .WithMany(e => e.CanceledTeams);

            builder.HasMany(e => e.Members)
                   .WithOne(e => e.TranslationTeam)
                   .HasForeignKey(e => e.TranslationTeamId);
        }
    }
}
