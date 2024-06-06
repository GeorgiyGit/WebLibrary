using Categories.Domain.Entities.Books;
using Categories.Domain.Entities.Shared;

namespace Categories.Domain.Entities.Tags
{
    public class Tag : Monitoring
    {
        public int Id { get; set; }
        public ICollection<TagTranslatedText> Names { get; set; } = new HashSet<TagTranslatedText>();

        public TagType Type { get; set; }
        public string TypeId { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
