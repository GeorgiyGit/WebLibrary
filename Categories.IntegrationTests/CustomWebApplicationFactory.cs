using Categories.Infrastructure;
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

namespace Categories.IntegrationTests
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        override protected void ConfigureWebHost(IWebHostBuilder builder)
        {
            var dbName = Guid.NewGuid().ToString();
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<CategoriesDbContext>));

                services.AddDbContext<CategoriesDbContext>(options =>
                {
                    options.UseInMemoryDatabase(dbName);
                });

                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

                CategoriesDbContext dbContext = CreateDbContext(services);
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            });
        }
        private static CategoriesDbContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CategoriesDbContext>();

            return dbContext;
        }
    }
}
