using Categories.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Categories.Domain.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LanguageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetCurrentLanguageCode()
        {
            try
            {
                var acceptLanguageHeader = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"];

                var code = acceptLanguageHeader.ToString();

                if (code == null || code.Length > 10) return "sk-SK";

                return code;
            }
            catch
            {
                return "sk-SK";
            }
        }
    }
}
