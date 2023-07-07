using FarmersMarketApi.Application.Blls;
using FarmersMarketApi.Application.InfrastructureInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmersMarketApi.Domain.Models;
using Microsoft.Extensions.Logging;

namespace FarmersMarketApi.Tests.FarmersMarketApplication.Unit
{
    [TestClass, TestCategory("Unit")]
    public class GetFarmersMarketsByZipCodeAsyncShould
    {
        private IFarmersMarketBll _sut;
        private Mock<IFarmersMarketRepository> _farmersMarketRepository;
        private string _expectedZipCode;

        [TestInitialize]
        public void SetUp()
        {
            _expectedZipCode = "123456";
            _farmersMarketRepository = new Mock<IFarmersMarketRepository>();
            var _logger = new Mock<ILogger<FarmersMarketBll>>();
            _sut = new FarmersMarketBll(_farmersMarketRepository.Object, _logger.Object);
        }

        [TestMethod]
        public async Task ReturnFarmersMarketsForGivenState()
        {
            _farmersMarketRepository.Setup(repo => repo.GetFarmersMarketsByZipCode(_expectedZipCode)).ReturnsAsync(new List<FarmersMarket>{
                new()
                {
                    Id = 101112,
                    Email = "farmers@market.com",
                    Name = "My Market",
                    Phone = "1234569871",
                    Website = "mymarket.com",
                    City = "Columbia",
                    State = "MO",
                    StreetAddress = "123 Farmers Street",
                    ZipCode = _expectedZipCode
                },
                new()
                {
                    Id = 789,
                    Email = "farmers@market.com",
                    Name = "My Market",
                    Phone = "1234569871",
                    Website = "mymarket.com",
                    City = "Columbia",
                    State = "MO",
                    StreetAddress = "123 Farmers Street",
                    ZipCode = _expectedZipCode

                }
            });

            var farmersMarkets = await _sut.GetFarmersMarketsByZipCodeAsync(_expectedZipCode);

            Assert.IsTrue(farmersMarkets.All(mkt => mkt.ZipCode.Equals(_expectedZipCode)));
            Assert.IsTrue(farmersMarkets.Count == 2);


        }
    }
}
