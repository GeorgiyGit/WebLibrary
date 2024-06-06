using Categories.Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Categories.Infrastructure.Builders.Tags
{
    internal class TagTypeBuilder : IEntityTypeConfiguration<TagType>
    {
        public void Configure(EntityTypeBuilder<TagType> builder)
        {
            builder.HasMany(e => e.Tags)
                   .WithOne(e => e.Type)
                   .HasForeignKey(e => e.TypeId);

            builder.HasMany(e => e.Names)
                   .WithOne(e => e.ValueEntity)
                   .HasForeignKey(e => e.ValueEntityId);
        }
    }
}
