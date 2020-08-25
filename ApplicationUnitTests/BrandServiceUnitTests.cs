using Application.Services;
using Application.Validation;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationUnitTests
{
    public class BrandServiceUnitTests
    {
        [Fact]
        public async Task CreateBeer_GivenAValidBeer_ShouldCallValidationAndCreateBeer()
        {
            //Arrange
            var beer = new Beer();

            var mockedValidation = new Mock<IBrandValidation>();
            mockedValidation.Setup(validation => validation.ValidateBeer(It.IsAny<Beer>()));

            var mockedDataAccess = new Mock<IBrandDataAccess>();
            mockedDataAccess.Setup(dataAccess => dataAccess.CreateBeer(It.IsAny<BeerEntity>()))
                .ReturnsAsync(Guid.Empty);

            var brandService = new BrandService(mockedDataAccess.Object, mockedValidation.Object);

            //Act
            var result = await brandService.CreateBeer(beer);

            //Assert
            mockedValidation.Verify(validation => validation.ValidateBeer(It.IsAny<Beer>()), Times.Once);
            mockedDataAccess.Verify(dataAccess => dataAccess.CreateBeer(It.IsAny<BeerEntity>()), Times.Once);
        }

        [Fact]
        public async Task CreateBeer_GivenAValidBeer_ShouldCallCreateBeerWithACorrectlyMappedBeerEntity()
        {
            //Arrange
            var beer = new Beer { Name = "Test name"};
            var beerEntity = beer.ToEntity();

            var mockedValidation = new Mock<IBrandValidation>();
            mockedValidation.Setup(validation => validation.ValidateBeer(It.IsAny<Beer>()));

            var mockedDataAccess = new Mock<IBrandDataAccess>();
            mockedDataAccess.Setup(dataAccess => dataAccess.CreateBeer(It.IsAny<BeerEntity>()))
                .ReturnsAsync(Guid.Empty);

            var brandService = new BrandService(mockedDataAccess.Object, mockedValidation.Object);

            //Act
            var result = await brandService.CreateBeer(beer);

            //Assert
            mockedDataAccess.Verify(dataAccess => dataAccess.CreateBeer(It.Is<BeerEntity>(entity => Serialize(entity) == Serialize(beerEntity))), Times.Once);
        }

        [Fact]
        public async Task CreateBeer_GivenAnInvalidBeer_ShouldThrowABadRequestHttpResult()
        {
            //Arrange
            var beer = new Beer();

            var mockedValidation = new Mock<IBrandValidation>();
            mockedValidation.Setup(validation => validation.ValidateBeer(It.IsAny<Beer>()))
                .ThrowsAsync(new HttpException(HttpStatusCode.BadRequest, "Bad request"));

            var brandService = new BrandService(null, mockedValidation.Object);

            //Assert
            await Assert.ThrowsAsync<HttpException>(async () => await brandService.CreateBeer(beer));
        }

        private string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}
