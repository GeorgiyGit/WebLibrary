using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.Interfaces;

namespace VirtualPeople.Domain.Services
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
