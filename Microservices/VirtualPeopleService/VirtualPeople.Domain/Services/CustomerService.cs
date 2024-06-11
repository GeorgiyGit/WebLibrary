using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.Interfaces;

namespace VirtualPeople.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string?> GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value;
        }
    }
}
