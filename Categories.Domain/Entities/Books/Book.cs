using Categories.Domain.Entities.Tags;

namespace Categories.Domain.Entities.Books
{
    public class Book
    {
        public int Id { get; set; }

        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
