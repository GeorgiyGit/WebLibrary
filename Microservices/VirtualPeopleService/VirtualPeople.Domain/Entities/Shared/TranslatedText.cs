using VirtualPeople.Domain.Entities.People;

namespace VirtualPeople.Domain.Entities.Shared
{
    public class TranslationTeamMemberRoleTranslatedText : TranslatedText<TranslationTeamMemberRole, string> { }
    public abstract class TranslatedText<Entity, EntityId>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string LanguageCode { get; set; }

        public Entity? ValueEntity { get; set; }
        public EntityId ValueEntityId { get; set; }
    }
}
