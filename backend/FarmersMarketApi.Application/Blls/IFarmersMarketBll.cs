using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmersMarketApi.Domain.Models;

namespace FarmersMarketApi.Application.Blls
{
    public interface IFarmersMarketBll
    {
        Task<List<FarmersMarket>> GetFarmersMarketsByStateAsync(string state);
    }
}
