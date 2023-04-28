using FarmersMarketApi.Application.Blls;
using FarmersMarketApi.Controllers;
using FarmersMarketApi.Domain.Models;
using FarmersMarketApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FarmersMarket = FarmersMarketApi.Domain.Models.FarmersMarket;

namespace FarmersMarketApi.Tests.FarmersMarketApi.Unit;

[TestClass, TestCategory("Unit")]
public class GetFarmersMarketsByStateShould
{
    private FarmersMarketsApiController _sut;
    private Mock<IFarmersMarketBll> _farmersMarketBll;
    private string _expectedState;

    [TestInitialize]
    public void SetUp()
    {
        _expectedState = "MO";
        _farmersMarketBll = new Mock<IFarmersMarketBll>();
        _sut = new FarmersMarketsApiController(_farmersMarketBll.Object);
    }

    [TestMethod]
    public async Task Return200_WhenThereAreFarmersMarketsForAGivenState()
    {
        _farmersMarketBll.Setup(bll => bll.GetFarmersMarketsByStateAsync(_expectedState)).ReturnsAsync(new List<FarmersMarket>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "My Market",
                OperationTimes = new OperationTimes(),
                Address = new Address
                {
                    StreetAddress = "123 Farmers Street",
                    City = "Columbia",
                    State = "MO",
                    ZipCode = "65203"
                },
                Phone = "6605551109",
                Email = "farmer@market.com",
                Website = "farmer.com"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "My Other Market",
                OperationTimes = new OperationTimes(),
                Address = new Address
                {
                    StreetAddress = "123 Farmers Street",
                    City = "Columbia",
                    State = "MO",
                    ZipCode = "65203"
                },
                Phone = "6605551109",
                Email = "farmer@market.com",
                Website = "farmer.com"
            }
        });
        var response = await _sut.GetFarmersMarketsByState(_expectedState) as ObjectResult;
        var modelApiResponse = response?.Value as ModelApiResponse;

        Assert.IsNotNull(response);
        Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        Assert.AreEqual(StatusCodes.Status200OK, modelApiResponse?.Code);
        Assert.IsNull(modelApiResponse?.Message);
        Assert.IsTrue(modelApiResponse?.FarmersMarkets.Count == 2);
    }

    [TestMethod]
    public async Task Return400_WhenStateIsInValid()
    {
        var response = await _sut.GetFarmersMarketsByState("LI") as ObjectResult;
        var modelApiResponse = response?.Value as ModelApiResponse;

        Assert.IsNotNull(response);
        Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);
        Assert.AreEqual(StatusCodes.Status400BadRequest, modelApiResponse?.Code);
        Assert.IsNotNull(modelApiResponse?.Message);
        Assert.IsFalse(modelApiResponse.FarmersMarkets.Any());
    }

    [TestMethod]
    public async Task Return404_WhenNoFarmersMarketsAreFoundForSpecifiedState()
    {
        _farmersMarketBll.Setup(bll => bll.GetFarmersMarketsByStateAsync(_expectedState)).ReturnsAsync(new List<FarmersMarket>());

        var response = await _sut.GetFarmersMarketsByState(_expectedState) as ObjectResult;
        var modelApiResponse = response?.Value as ModelApiResponse;

        Assert.IsNotNull(response);
        Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);
        Assert.AreEqual(StatusCodes.Status404NotFound, modelApiResponse?.Code);
        Assert.IsNotNull(modelApiResponse?.Message);
        Assert.IsFalse(modelApiResponse.FarmersMarkets.Any());
    }

    [TestMethod]
    public async Task Return500_WhenAnUnexpectedErrorOccurs()
    {
        _farmersMarketBll.Setup(bll => bll.GetFarmersMarketsByStateAsync(_expectedState)).Throws<Exception>();

        var response = await _sut.GetFarmersMarketsByState(_expectedState) as ObjectResult;
        var modelApiResponse = response?.Value as ModelApiResponse;

        Assert.IsNotNull(response);
        Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);
        Assert.AreEqual(StatusCodes.Status500InternalServerError, modelApiResponse?.Code);
        Assert.IsNotNull(modelApiResponse?.Message);
        Assert.IsFalse(modelApiResponse.FarmersMarkets.Any());
    }

}
