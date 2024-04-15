using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Interfaces
{
    public interface ICustomerService
    {
        public Task<string?> GetCurrentUserId();
    }
}
