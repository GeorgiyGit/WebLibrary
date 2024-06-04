using Categories.Domain.Entities.Books;
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
            await context.SaveChangesAsync();
        }
    }
}
