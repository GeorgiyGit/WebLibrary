using Categories.Domain.Entities;
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
    internal class TagNamesSeeder : IEntityTypeConfiguration<TagTranslatedText>
    {
        public void Configure(EntityTypeBuilder<TagTranslatedText> builder)
        {
            #region languageTags
            var langTagEnNameEN = new TagTranslatedText()
            {
                Id = 1,
                ValueEntityId=1,
                LanguageCode = Languages.EN,
                Value = "English"
            };
            var langTagEnNameSK = new TagTranslatedText()
            {
                Id = 2,
                ValueEntityId = 1,
                LanguageCode = Languages.SK,
                Value = "Angličtina"
            };

            var langTagSkNameEN = new TagTranslatedText()
            {
                Id = 3,
                ValueEntityId = 2,
                LanguageCode = Languages.EN,
                Value = "Slovak"
            };
            var langTagSkNameSK = new TagTranslatedText()
            {
                Id = 4,
                ValueEntityId = 2,
                LanguageCode = Languages.SK,
                Value = "Slovenčina"
            };
            #endregion

            builder.HasData(langTagEnNameEN,
                langTagEnNameSK,
                langTagSkNameEN,
                langTagSkNameSK);
        }
    }
}
