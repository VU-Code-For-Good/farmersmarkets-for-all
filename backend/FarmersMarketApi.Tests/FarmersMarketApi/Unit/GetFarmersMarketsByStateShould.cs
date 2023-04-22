using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Controllers;

namespace FarmersMarketApi.Tests;

[TestClass, TestCategory("Unit")]
public class GetFarmersMarketsByStateShould
{
    private FarmersMarketsApiController _sut;

    [TestInitialize]
    public void SetUp()
    {
        _sut = new FarmersMarketsApiController();
    }

    [TestMethod]
    public void Return500_WhenAnUnexpectedErrorOccurs()
    {
        Assert.Fail("");
    }

}
