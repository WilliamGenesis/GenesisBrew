using Application.Validation;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationUnitTests
{
    public class BrandValidationUnitTests
    {
        [Fact]
        public async Task ValidateBeer_GivenAValidBeer_ShouldNotThrowAnyException()
        {
            //Arrange
            var beer = new Beer
            {
                Name = "Test name",
                Brewery = new Brewery
                {
                    Id = Guid.NewGuid()
                }
            };

            var mockedBrandDataAccess = new Mock<IBrandDataAccess>();
            mockedBrandDataAccess.Setup(dataAccess => dataAccess.GetBrewery(It.IsAny<Guid>()))
                .ReturnsAsync(new BreweryEntity());

            var brandValidation = new BrandValidation(mockedBrandDataAccess.Object);

            //Act
            await brandValidation.ValidateBeer(beer);

            //Assert
            mockedBrandDataAccess.Verify(dataAccess => dataAccess.GetBrewery(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task ValidateBeer_GivenABeerWithAnEmptyBreweryId_ShouldThrowAHttpExceptionWithCorrectMessage()
        {
            //Arrange
            var beer = new Beer
            {
                Name = "Test name",
                Brewery = new Brewery
                {
                    Id = Guid.Empty
                }
            };

            var expectedValidationMessage = "A beer must always have a brewery";

            var brandValidation = new BrandValidation(null);

            //Act
            try
            {
                await brandValidation.ValidateBeer(beer);
            }
            catch(HttpException e)
            {
                //Assert
                Assert.Equal(HttpStatusCode.BadRequest, e.StatusCode);
                Assert.Equal(expectedValidationMessage, e.Message);
            }
        }

        [Fact]
        public async Task ValidateBeer_GivenABeerWithAnInvalidBreweryId_ShouldThrowAHttpExceptionWithCorrectMessage()
        {
            //Arrange
            var beer = new Beer
            {
                Name = "Test name",
                Brewery = new Brewery
                {
                    Id = Guid.NewGuid()
                }
            };

            var expectedValidationMessage = "A beer must always be linked to an existing brewery";

            var mockedBrandDataAccess = new Mock<IBrandDataAccess>();
            mockedBrandDataAccess.Setup(dataAccess => dataAccess.GetBrewery(It.IsAny<Guid>()))
                .ReturnsAsync((BreweryEntity)null);

            var brandValidation = new BrandValidation(mockedBrandDataAccess.Object);

            //Act
            try
            {
                await brandValidation.ValidateBeer(beer);
            }
            catch (HttpException e)
            {
                //Assert
                Assert.Equal(HttpStatusCode.BadRequest, e.StatusCode);
                Assert.Equal(expectedValidationMessage, e.Message);
            }
        }

        [Fact]
        public async Task ValidateBeerExists_GivenAValidBeer_ShouldNotThrowAnyException()
        {
            //Arrange
            var beerId = Guid.NewGuid();

            var mockedBrandDataAccess = new Mock<IBrandDataAccess>();
            mockedBrandDataAccess.Setup(dataAccess => dataAccess.GetBeer(It.IsAny<Guid>()))
                .ReturnsAsync(new BeerEntity());

            var brandValidation = new BrandValidation(mockedBrandDataAccess.Object);

            //Act
            await brandValidation.ValidateBeerExists(beerId);

            //Assert
            mockedBrandDataAccess.Verify(dataAccess => dataAccess.GetBeer(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task ValidateBeerExists_GivenANonExisting_ShouldThrowAHttpExceptionWithCorrectMessage()
        {
            //Arrange
            var beerId = Guid.NewGuid();

            var expectedValidationMessage = "The beer does not exist";

            var mockedBrandDataAccess = new Mock<IBrandDataAccess>();
            mockedBrandDataAccess.Setup(dataAccess => dataAccess.GetBeer(It.IsAny<Guid>()))
                .ReturnsAsync((BeerEntity)null);

            var brandValidation = new BrandValidation(mockedBrandDataAccess.Object);

            //Act
            try
            {
                await brandValidation.ValidateBeerExists(beerId);
            }
            catch (HttpException e)
            {
                //Assert
                Assert.Equal(HttpStatusCode.BadRequest, e.StatusCode);
                Assert.Equal(expectedValidationMessage, e.Message);
            }
        }
    }
}
