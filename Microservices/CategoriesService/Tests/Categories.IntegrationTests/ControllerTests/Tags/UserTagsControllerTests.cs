using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Resources.Tags;
using Categories.Infrastructure;
using Categories.IntegrationTests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Categories.IntegrationTests.ControllerTests.Tags
{
    public class UserTagsControllerTests
    {
        #region get-tags
        [Fact]
        public async Task Get_Tags_SK_Without_FilterStr_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            var request = new GetTagsRequest()
            {
                FilterStr = "",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/UserTags/get-tags", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(2);

            var enTag = tags.Where(e => e.Name == "Angličtina").FirstOrDefault();
            enTag.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Tags_EN_Without_FilterStr_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");

            var request = new GetTagsRequest()
            {
                FilterStr = "",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/UserTags/get-tags", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(2);

            var enTag = tags.Where(e => e.Name == "English").FirstOrDefault();
            enTag.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Tags_SK_With_FilterStr_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            var request = new GetTagsRequest()
            {
                FilterStr = "Angl",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/UserTags/get-tags", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(1);

            var enTag = tags.Where(e => e.Name == "Angličtina").FirstOrDefault();
            enTag.Should().NotBeNull();
        }
        #endregion

        #region get-all-compraced
        [Fact]
        public async Task Get_All_Compraced_SK_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            // Act
            var response = await client.GetAsync("/api/v1/UserTags/get-all-compraced");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(2);

            var langGroup = tagGroups.Where(e => e.Type.Id ==TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(2);
            langGroup.Type.Name.Should().Be("Jazyky");
        }

        [Fact]
        public async Task Get_All_Compraced_EN_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");

            // Act
            var response = await client.GetAsync("/api/v1/UserTags/get-all-compraced");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(2);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(2);
            langGroup.Type.Name.Should().Be("Languages");
        }
        #endregion

        #region get-all-from-book
        [Fact]
        public async Task Get_All_From_Book_SK_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<CategoriesDbContext>();

                await Utilities.InitializeBook(db);
            }

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            // Act
            var response = await client.GetAsync("/api/v1/UserTags/get-all-from-book/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(3);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(1);
            langGroup.Type.Name.Should().Be("Jazyky");
        }

        [Fact]
        public async Task Get_All_From_Book_EN_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<CategoriesDbContext>();

                await Utilities.InitializeBook(db);
            }

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");

            // Act
            var response = await client.GetAsync("/api/v1/UserTags/get-all-from-book/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(3);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(1);
            langGroup.Type.Name.Should().Be("Languages");
        }
        #endregion

        #region get-from-book
        [Fact]
        public async Task Get_From_Book_SK_Success()
        {
            // Arrange
            var application = new CustomWebApplicationFactory();
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<CategoriesDbContext>();

                await Utilities.InitializeBook(db);
            }

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");
            var request = new GetBookTagsRequest()
            {
                BookId = 1,
                TagTypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/UserTags/get-from-book", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags= await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(1);
        }
        #endregion
    }
}
