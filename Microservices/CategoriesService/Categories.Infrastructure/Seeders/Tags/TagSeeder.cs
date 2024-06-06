using Categories.Domain.Entities;
using Categories.Domain.Entities.Tags;
using Categories.Domain.Resources.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Infrastructure.Seeders.Tags
{
    internal class TagSeeder : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            var langTagEn = new Tag()
            {
                Id = 1,
                TypeId = TagTypes.LanguageTag
            };
            var langTagSk = new Tag()
            {
                Id = 2,
                TypeId = TagTypes.LanguageTag
            };

            builder.HasData(langTagEn, langTagSk);
        }
    }
}
