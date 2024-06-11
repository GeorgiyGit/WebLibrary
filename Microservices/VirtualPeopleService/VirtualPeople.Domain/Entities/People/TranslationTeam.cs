using VirtualPeople.Domain.Entities.Books;

namespace VirtualPeople.Domain.Entities.People
{
    public class TranslationTeam
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string? ImageGroupId { get; set; }

        public ICollection<TeamBook> InPlansBooks { get; set; } = new HashSet<TeamBook>();
        public ICollection<TeamBook> InProcessBooks { get; set; } = new HashSet<TeamBook>();
        public ICollection<TeamBook> CanceledBooks { get; set; } = new HashSet<TeamBook>();

        public int MembersCount { get; set; }
        public ICollection<TranslationTeamMember> Members { get; set; } = new HashSet<TranslationTeamMember>();
    }
}
