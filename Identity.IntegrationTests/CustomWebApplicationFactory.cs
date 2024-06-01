using Identity.Infrastructure;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
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
                // Remove the existing DbContextOptions
                services.RemoveAll(typeof(DbContextOptions<IdentityServiceDbContext>));

                // Register a new DBContext that will use our test connection string
                services.AddDbContext<IdentityServiceDbContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                });

                // Add the authentication handler
                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

                // Delete the database (if exists) to ensure we start clean
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
