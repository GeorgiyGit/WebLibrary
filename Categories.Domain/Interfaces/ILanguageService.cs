
namespace Categories.Domain.Interfaces
{
    public interface ILanguageService
    {
        public Task<string> GetCurrentLanguageCode();
    }
}
