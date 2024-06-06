using Categories.Domain.Entities.Tags;

namespace Categories.Domain.Entities
{
    public class TagTypeTranslatedText : TranslatedText<TagType, string> { }
    public class TagTranslatedText : TranslatedText<Tag, int> { }
    public abstract class TranslatedText<Entity, EntityId>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string LanguageCode { get; set; }

        public Entity? ValueEntity { get; set; }
        public EntityId ValueEntityId { get; set; }
    }
}
