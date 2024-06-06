using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Entities.Tags;
using Categories.Domain.Resources.Tags;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Categories.IntegrationTests.ControllerTests.TagTypesTests
{
    public class TagTypesControllerTests
    {
        #region get-all
        [Fact]
        public async Task Get_All_SK_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            // Act
            var response = await client.GetAsync("/api/v1/TagTypes/get-all");

            // Assert
            response.EnsureSuccessStatusCode();

            var types = await response.Content.ReadFromJsonAsync<ICollection<TagTypeDTO>>();
            types.Should().NotBeNull();
            types.Count().Should().Be(3);

            var tagType = types.Where(e => e.Id == TagTypes.Tag).FirstOrDefault();

            tagType.Should().NotBeNull();
            tagType.Name.Should().Be("Štítok");
        }

        [Fact]
        public async Task Get_All_EN_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");

            // Act
            var response = await client.GetAsync("/api/v1/TagTypes/get-all");

            // Assert
            response.EnsureSuccessStatusCode();

            var types = await response.Content.ReadFromJsonAsync<ICollection<TagTypeDTO>>();
            types.Should().NotBeNull();
            types.Count().Should().Be(3);

            var tagType = types.Where(e => e.Id == TagTypes.Tag).FirstOrDefault();

            tagType.Should().NotBeNull();
            tagType.Name.Should().Be("Tag");
        }
        #endregion

        #region get-by-id
        [Fact]
        public async Task Get_By_Id_SK_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            // Act
            var response = await client.GetAsync("/api/v1/TagTypes/get-by-id/" + TagTypes.Tag);

            // Assert
            response.EnsureSuccessStatusCode();

            var type = await response.Content.ReadFromJsonAsync<TagTypeDTO>();
            type.Should().NotBeNull();
            type.Name.Should().Be("Štítok");
        }

        [Fact]
        public async Task Get_By_Id_EN_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");

            // Act
            var response = await client.GetAsync("/api/v1/TagTypes/get-by-id/" + TagTypes.Tag);

            // Assert
            response.EnsureSuccessStatusCode();

            var type = await response.Content.ReadFromJsonAsync<TagTypeDTO>();
            type.Should().NotBeNull();
            type.Name.Should().Be("Tag");
        }
        #endregion
    }
}
