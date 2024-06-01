using Identity.Domain.Entities.Customers;
using Identity.Domain.Resources.Customers;
using Identity.Infrastructure;
using Identity.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        override protected void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<IdentityServiceDbContext>));

                services.AddDbContext<IdentityServiceDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

                IdentityServiceDbContext dbContext = CreateDbContext(services);
                dbContext.Database.EnsureDeleted();
            });
        }
        private static IdentityServiceDbContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<IdentityServiceDbContext>();

            return dbContext;
        }
    }
}
