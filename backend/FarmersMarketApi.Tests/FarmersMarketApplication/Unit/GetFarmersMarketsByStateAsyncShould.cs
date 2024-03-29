using FarmersMarketApi.Application.Blls;
using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Controllers;
using FarmersMarketApi.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FarmersMarketApi.Tests.FarmersMarketApplication.Unit
{
    [TestClass, TestCategory("Unit")]
    public class GetFarmersMarketsByStateAsyncShould
    {
        private IFarmersMarketBll _sut;
        private Mock<IFarmersMarketRepository> _farmersMarketRepository;
        private string _expectedState;

        [TestInitialize]
        public void SetUp()
        {
            _expectedState = "MO";
            _farmersMarketRepository = new Mock<IFarmersMarketRepository>();
            var mockLogger =  new Mock<ILogger<FarmersMarketBll>>();
            _sut = new FarmersMarketBll(_farmersMarketRepository.Object, mockLogger.Object);
        }

        [TestMethod]
        public async Task ReturnFarmersMarketsForGivenState()
        {
            _farmersMarketRepository.Setup(repo => repo.GetFarmersMarketsByState(_expectedState)).ReturnsAsync(new List<FarmersMarket>{
               new FarmersMarket
               {
                    Id = 101112,
                    Email = "farmers@market.com",
                    Name = "My Market",
                    Phone = "1234569871",
                    Website = "mymarket.com",
                    City = "Columbia",
                    State = _expectedState,
                    StreetAddress = "123 Farmers Street",
                    ZipCode = "65203"
               },
               new FarmersMarket
               {
                    Id = 789,
                    Email = "farmers@market.com",
                    Name = "My Market",
                    Phone = "1234569871",
                    Website = "mymarket.com",
                    City = "Columbia",
                    State = _expectedState,
                    StreetAddress = "123 Farmers Street",
                    ZipCode = "65203"

               }
            });

            var farmersMarkets = await _sut.GetFarmersMarketsByStateAsync(_expectedState);

            Assert.IsTrue(farmersMarkets.All(mkt => mkt.State.Equals(_expectedState)));
            Assert.IsTrue(farmersMarkets.Count == 2);


        }

    }
}
