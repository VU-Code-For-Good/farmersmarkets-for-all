using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmersMarketApi.Application.Blls;
using FarmersMarketApi.Controllers;
using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FarmersMarket = FarmersMarketApi.Domain.Models.FarmersMarket;

namespace FarmersMarketApi.Tests.FarmersMarketApi.Unit
{
    [TestClass, TestCategory("Unit")]
    public class GetFarmersMarketByZipCodeShould
    {
        private FarmersMarketsApiController _sut;
        private Mock<IFarmersMarketBll> _farmersMarketBll;
       

        [TestInitialize]
        public void SetUp()
        {
            _farmersMarketBll = new Mock<IFarmersMarketBll>();
            var _mockLogger = new Mock<ILogger<FarmersMarketsApiController>>();
            _sut = new FarmersMarketsApiController(_farmersMarketBll.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task ReturnSuccessWithFarmersMarketsWhenAvailable()
        {
            // Arrange
            var zipCode = "12345";
            var expectedFarmersMarkets = new List<FarmersMarket>
            {
                new() { Id = 1, Name = "Market 1", Phone = "1234567890" },
                new() { Id = 2, Name = "Market 2", Phone = "9876543210" }
            };

            _farmersMarketBll
                .Setup(b => b.GetFarmersMarketsByZipCodeAsync(zipCode))
                .ReturnsAsync(expectedFarmersMarkets);

            // Act
            var result = await _sut.GetFarmersMarketsByZipcode(zipCode);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            var apiResponse = (ModelApiResponse)objectResult.Value;
            Assert.AreEqual(200, apiResponse.Code);
            Assert.AreEqual("Successful operation", apiResponse.Message);
            Assert.AreEqual(expectedFarmersMarkets.Count, apiResponse.FarmersMarkets.Count);
        }

        [TestMethod]
        public async Task ReturnNotFoundWhenNoFarmersMarketsAvailable()
        {
            // Arrange
            var zipCode = "12345";

            _farmersMarketBll
                .Setup(b => b.GetFarmersMarketsByZipCodeAsync(zipCode))
                .ReturnsAsync(new List<FarmersMarket>());

            // Act
            var result = await _sut.GetFarmersMarketsByZipcode(zipCode);

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            var statusCodeResult = (StatusCodeResult)result;
            Assert.AreEqual(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public async Task ReturnInternalServerErrorOnException()
        {
            // Arrange
            var zipCode = "12345";
            var errorMessage = "An unexpected error occurred.";
   
            _farmersMarketBll
                .Setup(b => b.GetFarmersMarketsByZipCodeAsync(zipCode))
                .ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await _sut.GetFarmersMarketsByZipcode(zipCode);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            var apiResponse = (ModelApiResponse)objectResult.Value;
            Assert.AreEqual(500, apiResponse.Code);
            Assert.AreEqual("Unexpected error occurred: " + errorMessage, apiResponse.Message);
        }
    }
}
