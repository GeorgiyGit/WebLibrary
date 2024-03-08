using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace DetailedBooks.Domain.Interfaces
{
    public interface ICustomerService
    {
        public Task<string?> GetCurrentUserId();
    }
}
