
namespace VirtualPeople.Domain.Entities.People
{
    public class TranslationTeamMember
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public TranslationTeam TranslationTeam { get; set; }
        public int TranslationTeamId { get; set; }

        public TranslationTeamMemberRole Role { get; set; }
        public string RoleId { get; set; }
    }
}
