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
    internal class TranslationTeamMemberBuilder : IEntityTypeConfiguration<TranslationTeamMember>
    {
        public void Configure(EntityTypeBuilder<TranslationTeamMember> builder)
        {
            builder.HasOne(e => e.Role)
                   .WithMany(e => e.Members)
                   .HasForeignKey(e => e.RoleId);

            builder.HasOne(e => e.TranslationTeam)
                   .WithMany(e => e.Members)
                   .HasForeignKey(e => e.TranslationTeamId);
        }
    }
}
