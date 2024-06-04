using Categories.Domain.Entities;
using Categories.Domain.Entities.Books;
using Categories.Domain.Entities.Tags;
using Categories.Domain.Resources.Tags;
using Categories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.IntegrationTests.Helpers
{
    public class Utilities
    {
        public static async Task InitializeBook(CategoriesDbContext context)
        {
            var tag = context.Tags.Where(e => e.TypeId == TagTypes.LanguageTag).Include(e=>e.Books).FirstOrDefault();
            var book = new Book()
            {
                Id = 1
            };

            book.Tags.Add(tag);
            tag.Books.Add(book);
            await context.Books.AddAsync(book);

            var deletedLanguageTag = new Tag()
            {
                Id = 100,
                TypeId = TagTypes.LanguageTag,
                IsDeleted = true,
            };

            var dlTagNameEn = new TagTranslatedText()
            {
                LanguageCode = Languages.EN,
                ValueEntity = deletedLanguageTag,
                Id = 100,
                Value = "Deleted"
            };
            var dlTagNameSk = new TagTranslatedText()
            {
                LanguageCode = Languages.SK,
                ValueEntity = deletedLanguageTag,
                Id = 101,
                Value = "Odstránené"
            };
            await context.Tags.AddAsync(deletedLanguageTag);
            await context.TagTranslatedTexts.AddRangeAsync(dlTagNameEn, dlTagNameSk);

            book.Tags.Add(deletedLanguageTag);
            deletedLanguageTag.Books.Add(book);


            await context.SaveChangesAsync();
        }
    }
}
