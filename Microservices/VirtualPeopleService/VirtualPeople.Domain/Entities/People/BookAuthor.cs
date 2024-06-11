using VirtualPeople.Domain.Entities.Shared;

namespace VirtualPeople.Domain.Entities.People
{
    public class BookAuthor : Monitoring
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddedCustomerId { get; set; }

        public int BookCount { get; set; }
        public string? ImageGroupId { get; set; }

        public bool IsModerated { get; set; }
    }
}
