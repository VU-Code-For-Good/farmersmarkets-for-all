using FarmersMarketApi.Application.InfrastructureInterfaces;
using FarmersMarketApi.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FarmersMarketApi.Tests.FarmersMarketInfrastructure.Unit.Repositories
{
    [TestClass, TestCategory("Unit")]
    public class GetFarmersMarketsShould
    {
        private IFarmersMarketRepository _sut;
     
        
        [TestInitialize]
        public void SetUp()
        {
           
            _sut = new FarmersMarketRepository();
        }
    }
}
