using FluentAssertions;
using Identity.Domain.DTOs.AccountDTOs.Requests;
using Identity.Domain.DTOs.AccountDTOs.Responses;
using Identity.Domain.Entities.Customers;
using Identity.Infrastructure;
using Identity.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IntegrationTests.ControllerTests
{
    public class AccountControllerTests
    {
        #region sign-up
        [Fact]
        public async Task Sign_Up_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            SignUpRequest request = new SignUpRequest()
            {
                Email = "sladkovsky.george@test.com",
                Password = "12345678",
                UserName = "George"
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/account/sign-up", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var token = await response.Content.ReadFromJsonAsync<TokenDTO>();
            token.Should().NotBeNull();
            token.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Sign_Up_Failure()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            SignUpRequest request = new SignUpRequest()
            {
                Email = "sladkovsky.george",
                Password = "12345678",
                UserName = "George"
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/account/sign-up", request);

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
        #endregion

        #region log-in
        [Fact]
        public async Task Log_In_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<IdentityServiceDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                Utilities.InitializeDbForTests(db,userManager,roleManager);
            }
            LogInRequest request = new LogInRequest()
            {
                Email = UserSettings.Email,
                Password = UserSettings.Password
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/account/log-in", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var token = await response.Content.ReadFromJsonAsync<TokenDTO>();
            token.Should().NotBeNull();
            token.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Log_In_Failure()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<IdentityServiceDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await Utilities.InitializeDbForTests(db, userManager, roleManager);
            }
            LogInRequest request = new LogInRequest()
            {
                Email = UserSettings.Email,
                Password = "12345678Grear1334"
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/account/log-in", request);

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
        #endregion
    }
}
