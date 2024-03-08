using AutoMapper;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DetailedBooks.UnitTests.Books
{
    public class BooksQueryHandlersTests
    {
        [Fact]
        public void GetFullBookByIdHandler_ReturnsBook()
        {
            var profiles = new List<Profile>()
            {
                new ProductProfile(),
                new ProductStatusProfile(),
                new ImageProfile()
            };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            var mapper = new Mapper(mapperConfiguration);

            var localizer = A.Fake<IStringLocalizer<ErrorMessages>>();
            var languageService = A.Fake<ILanguageService>();
            var userService = A.Fake<IUserService>();


            string? customerId = null;
            A.CallTo(() => languageService.GetCurrentLanguageCode()).Returns("uk-UA");
            A.CallTo(() => userService.GetCurrentUserId()).Returns(customerId);

            var handler = new GetSimpleProductsHandler(dbContext, localizer, languageService, mapper, userService);

            var request = new GetSimpleProductsRequest()
            {
                FilterType = ProductFilterTypes.ByTimeDesc,
                PageParameters = new Shared.Application.DTOs.Common.PageParameters
                {
                    PageNumber = 1,
                    PageSize = 10
                },
                FilterStr = "",
                ProductStatusId = ProductStatuses.Sale
            };
            var command = mapper.Map<GetSimpleProducts>(request);
            //Act
            var products = await handler.Handle(command, CancellationToken.None);

            //Assert
            products.Should().NotBeNull();
            products.Count().Should().Be(10);
            products.Should().BeOfType<List<SimpleProductDTO>>();

            foreach (var product in products)
            {
                product.Status.Should().NotBeNull();
                product.Status.Id.Should().BeSameAs(ProductStatuses.Sale);
            }
        }
    }
}
