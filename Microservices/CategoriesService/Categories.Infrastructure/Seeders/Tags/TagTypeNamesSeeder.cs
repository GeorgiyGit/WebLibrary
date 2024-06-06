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
    internal class TagTypeNamesSeeder : IEntityTypeConfiguration<TagTypeTranslatedText>
    {
        public void Configure(EntityTypeBuilder<TagTypeTranslatedText> builder)
        {
            var languageTypeNameEN = new TagTypeTranslatedText()
            {
                Id = 1,
                ValueEntityId = TagTypes.LanguageTag,
                LanguageCode = Languages.EN,
                Value = "Languages"
            };
            var languageTypeNameSK = new TagTypeTranslatedText()
            {
                Id = 2,
                ValueEntityId = TagTypes.LanguageTag,
                LanguageCode = Languages.SK,
                Value = "Jazyky"
            };

            var tagTypeNameEN = new TagTypeTranslatedText()
            {
                Id = 3,
                ValueEntityId = TagTypes.Tag,
                LanguageCode = Languages.EN,
                Value = "Tag"
            };
            var tagTypeNameSK = new TagTypeTranslatedText()
            {
                Id = 4,
                ValueEntityId = TagTypes.Tag,
                LanguageCode = Languages.SK,
                Value = "Štítok"
            };

            var bookTypeNameEN = new TagTypeTranslatedText()
            {
                Id = 5,
                ValueEntityId = TagTypes.BookType,
                LanguageCode = Languages.EN,
                Value = "Type"
            };
            var bookTypeNameSK = new TagTypeTranslatedText()
            {
                Id = 6,
                ValueEntityId = TagTypes.BookType,
                LanguageCode = Languages.SK,
                Value = "Typ"
            };

            builder.HasData(languageTypeNameEN,
                languageTypeNameSK,
                tagTypeNameEN,
                tagTypeNameSK,
                bookTypeNameEN,
                bookTypeNameSK);
        }
    }
}
