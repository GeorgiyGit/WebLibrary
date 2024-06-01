using Identity.Domain.Entities.Customers;
using Identity.Domain.Resources.Customers;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static async Task InitializeDbForTests(IdentityServiceDbContext context, UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }

            var testUser = new Customer()
            {
                UserName = UserSettings.UserName,
                Email = UserSettings.Email
            };
            var result = await userManager.CreateAsync(testUser, UserSettings.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(testUser, UserRoles.User);
            }
            await context.SaveChangesAsync();
        }
    }
}
