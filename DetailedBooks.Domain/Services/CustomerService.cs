using DetailedBooks.Domain.Interfaces;
using System.Security.Claims;

namespace DetailedBooks.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly DetailedBook _dbContext;

        //public CustomerService(IHttpContextAccessor httpContextAccessor)
        //{
            //_httpContextAccessor = httpContextAccessor;
            //_dbContext = dbContext;
        //}

        public async Task<string?> GetCurrentUserId()
        {
            //var email = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            //if (email == null)
            return null;
            //var customer = await _dbContext.Customers.Where(e => e.Email == email).FirstOrDefaultAsync();

            //if (customer == null) return null;
            //return customer.Id;
        }
    }
}
