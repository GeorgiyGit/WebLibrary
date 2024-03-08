using DetailedBooks.Domain.Entities.Customers;
using DetailedBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDetailedBookDbContext _dbContext;

        public CustomerService(IHttpContextAccessor httpContextAccessor,
            IDetailedBookDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task<string?> GetCurrentUserId()
        {
            var email = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null) return null;
            var customer = await _dbContext.Customers.Where(e => e.Email == email).FirstOrDefaultAsync();

            if (customer == null) return null;
            return customer.Id;
        }
    }
}
