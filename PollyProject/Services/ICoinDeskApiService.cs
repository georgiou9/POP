using PollyProject.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollyProject.Services
{
    public interface ICoinDeskApiService
    {
        [Get("/v1/bpi/currentprice.json")]
        Task<ApiResponse<BitcoinPriceIndex>> GetCurrentPriceV1Async();
    }
}
