using Categories.Domain.Entities;
using Categories.Domain.Entities.Books;
using Categories.Domain.Entities.Tags;
using Categories.Infrastructure.Builders.Tags;
using Microsoft.EntityFrameworkCore;

namespace Categories.Infrastructure
{
    public class CategoriesDbContext : DbContext
    {
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagType> TagTypes { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<TagTranslatedText> TagTranslatedTexts { get; set; }
        public virtual DbSet<TagTypeTranslatedText> TagTypeTranslatedTexts { get; set; }

        public CategoriesDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagBuilder).Assembly);
        }
    }
}
