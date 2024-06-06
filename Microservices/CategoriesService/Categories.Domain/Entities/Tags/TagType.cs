
namespace Categories.Domain.Entities.Tags
{
    public class TagType
    {
        public string Id { get; set; }
        public ICollection<TagTypeTranslatedText> Names { get; set; } = new HashSet<TagTypeTranslatedText>();
        
        public bool IsCompraced { get; set; }
        public bool IsCancelable { get; set; }

        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
