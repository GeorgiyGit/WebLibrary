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
    internal class TagTypeSeeder : IEntityTypeConfiguration<TagType>
    {
        public void Configure(EntityTypeBuilder<TagType> builder)
        {
            var languageType = new TagType()
            {
                Id = TagTypes.LanguageTag,
                IsCancelable = true,
                IsCompraced = true,
            };

            var tagType = new TagType()
            {
                Id = TagTypes.Tag,
                IsCancelable = true,
                IsCompraced = false,
            };

            var bookType = new TagType()
            {
                Id = TagTypes.BookType,
                IsCancelable = true,
                IsCompraced = true,
            };

            builder.HasData(languageType, tagType, bookType);
        }
    }
}
