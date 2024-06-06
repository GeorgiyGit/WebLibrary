using Categories.Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Categories.Infrastructure.Builders.Tags
{
    internal class TagBuilder : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(e => e.Names)
                   .WithOne(e => e.ValueEntity)
                   .HasForeignKey(e => e.ValueEntityId);

            builder.HasOne(e => e.Type)
                   .WithMany(e => e.Tags)
                   .HasForeignKey(e => e.TypeId);

            builder.HasMany(e => e.Books)
                   .WithMany(e => e.Tags);
        }
    }
}
