using Microsoft.EntityFrameworkCore;
using VirtualPeople.Domain.Entities.Books;
using VirtualPeople.Domain.Entities.People;
using VirtualPeople.Domain.Entities.Shared;
using VirtualPeople.Infrastructure.Builders.People;

namespace VirtualPeople.Infrastructure
{
    public class VirtualPeopleDbContext : DbContext
    {
        #region People
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<TranslationTeam> TranslationTeam { get; set; }
        public DbSet<TranslationTeamMember> TranslationTeamMembers { get; set; }
        public DbSet<TranslationTeamMemberRole> TranslationTeamMemberRoles { get; set; }
        #endregion

        public DbSet<TeamBook> TeamBooks { get; set; }
        public DbSet<TranslationTeamMemberRoleTranslatedText> TranslationTeamMemberRoleTranslatedTexts { get; set; }

        public VirtualPeopleDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookAuthorBuilder).Assembly);
        }
    }
}
