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
    internal class TranslationTeamMemberRoleBuilder : IEntityTypeConfiguration<TranslationTeamMemberRole>
    {
        public void Configure(EntityTypeBuilder<TranslationTeamMemberRole> builder)
        {
            builder.HasMany(e => e.Members)
                   .WithOne(e => e.Role)
                   .HasForeignKey(e => e.RoleId);

            builder.HasMany(e => e.Names)
                   .WithOne(e => e.ValueEntity)
                   .HasForeignKey(e => e.ValueEntityId);
        }
    }
}
