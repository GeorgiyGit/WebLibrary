using VirtualPeople.Domain.Entities.Shared;

namespace VirtualPeople.Domain.Entities.People
{
    public class TranslationTeamMemberRole
    {
        public string Id { get; set; }
        public ICollection<TranslationTeamMemberRoleTranslatedText> Names { get; set; } = new HashSet<TranslationTeamMemberRoleTranslatedText>();

        public ICollection<TranslationTeamMember> Members { get; set; } = new HashSet<TranslationTeamMember>();
    }
}
