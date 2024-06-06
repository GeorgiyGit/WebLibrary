
namespace DetailedBooks.Domain.Entities.Shared
{
    public interface IMonitoring
    {
        public DateTime DataCreationTime { get; set; }
        public DateTime? DataLastDeleteTime { get; set; }
        public DateTime? DataLastEditTime { get; set; }
        
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
