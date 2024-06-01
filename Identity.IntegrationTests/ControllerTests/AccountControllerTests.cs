using FluentAssertions;
using Identity.Domain.DTOs.AccountDTOs.Requests;
using Identity.Domain.DTOs.AccountDTOs.Responses;
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
    }
}
