using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.DTOs.TranslatedTextDTOs;
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
    public class ModeratorTagsControllerTests
    {
        #region get-tags
        [Fact]
        public async Task Get_Tags_SK_Without_FilterStr_Success()
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

            var request = new GetTagsRequest()
            {
                FilterStr = "",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/ModeratorTags/get-tags", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(3);

            var enTag = tags.Where(e => e.Name == "Angličtina").FirstOrDefault();
            enTag.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Tags_EN_Without_FilterStr_Success()
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

            var request = new GetTagsRequest()
            {
                FilterStr = "",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/ModeratorTags/get-tags", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(3);

            var enTag = tags.Where(e => e.Name == "English").FirstOrDefault();
            enTag.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Tags_SK_With_FilterStr_Success()
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

            var request = new GetTagsRequest()
            {
                FilterStr = "Angl",
                TypeId = TagTypes.LanguageTag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/ModeratorTags/get-tags", request);

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
            using (var scope = application.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scope.ServiceProvider.GetRequiredService<CategoriesDbContext>();

                await Utilities.InitializeBook(db);
            }

            var client = application.CreateClient();
            client.DefaultRequestHeaders.Add("Accept-Language", "sk-SK");

            // Act
            var response = await client.GetAsync("/api/v1/ModeratorTags/get-all-compraced");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(2);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(3);
            langGroup.Type.Name.Should().Be("Jazyky");
        }

        [Fact]
        public async Task Get_All_Compraced_EN_Success()
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
            var response = await client.GetAsync("/api/v1/ModeratorTags/get-all-compraced");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(2);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(3);
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
            var response = await client.GetAsync("/api/v1/ModeratorTags/get-all-from-book/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(3);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(2);
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
            var response = await client.GetAsync("/api/v1/ModeratorTags/get-all-from-book/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var tagGroups = await response.Content.ReadFromJsonAsync<ICollection<TagGroupDTO>>();
            tagGroups.Should().NotBeNull();
            tagGroups.Count().Should().Be(3);

            var langGroup = tagGroups.Where(e => e.Type.Id == TagTypes.LanguageTag).FirstOrDefault();
            langGroup.Should().NotBeNull();
            langGroup.Tags.Should().NotBeNullOrEmpty();
            langGroup.Tags.Count().Should().Be(2);
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
            var response = await client.PostAsJsonAsync("/api/v1/ModeratorTags/get-from-book", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<ICollection<SimpleTagDTO>>();
            tags.Should().NotBeNull();
            tags.Count().Should().Be(2);
        }
        #endregion

        #region add-update
        [Fact]
        public async Task Add_Success()
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
            var names = new List<TranslatedTextDTO>()
            {
                new TranslatedTextDTO()
                {
                    LanguageCode=Languages.EN,
                    Value="Name1"
                },
                new TranslatedTextDTO()
                {
                    LanguageCode=Languages.SK,
                    Value="Meno1"
                }
            };
            var request = new AddTagRequest()
            {
                Names = names,
                TypeId = TagTypes.Tag
            };
            // Act
            var response = await client.PostAsJsonAsync("/api/v1/ModeratorTags/add", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var tags = await response.Content.ReadFromJsonAsync<int>();
            tags.Should().NotBe(0);
        }

        [Fact]
        public async Task Update_Success()
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
            var names = new List<TranslatedTextDTO>()
            {
                new TranslatedTextDTO()
                {
                    LanguageCode=Languages.EN,
                    Value="Name1"
                },
                new TranslatedTextDTO()
                {
                    LanguageCode=Languages.SK,
                    Value="Meno1"
                }
            };
            var request = new UpdateTagRequest()
            {
                Names = names,
                Id=1,
            };
            // Act
            var response = await client.PutAsJsonAsync("/api/v1/ModeratorTags/update", request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        #endregion

        #region delete-restore
        [Fact]
        public async Task Delete_Success()
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
            var response = await client.DeleteAsync("/api/v1/ModeratorTags/delete/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Restore_Success()
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
            var response = await client.PostAsync("/api/v1/ModeratorTags/restore/100", null);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
