using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.Entities.People;

namespace VirtualPeople.Domain.Entities.Books
{
    public class TeamBook
    {
        public int Id { get; set; }

        public ICollection<TranslationTeam> InPlansTeams { get; set; } = new HashSet<TranslationTeam>();
        public ICollection<TranslationTeam> InProcessTeams { get; set; } = new HashSet<TranslationTeam>();
        public ICollection<TranslationTeam> CanceledTeams { get; set; } = new HashSet<TranslationTeam>();
    }
}
