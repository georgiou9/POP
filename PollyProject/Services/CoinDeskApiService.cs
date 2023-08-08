using Refit;
using PollyProject.Models;
using Polly;
using System.Net;

namespace PollyProject.Services
{
    public class CoinDeskApiService
    {
        private ICoinDeskApiService _coinDeskApiService;
        private static int RETRIES = 3;

        public CoinDeskApiService(string apiUrl) => _coinDeskApiService = RestService.For<ICoinDeskApiService>(apiUrl);

        public async Task<ApiResponse<BitcoinPriceIndex>> GetCurrentPriceV1Async()
        { 
            //return await _coinDeskApiService.GetCurrentPriceV1Async();
            return await Policy
                .Handle<Exception>()
                .RetryAsync(RETRIES)
                .ExecuteAsync(async () => await _coinDeskApiService.GetCurrentPriceV1Async())
                .ConfigureAwait(false);
            
        }

        public async Task<ApiResponse<BitcoinPriceIndex>> GetCurrentPriceV1Policy2Async()
        {
            return await Policy
                // When recieving an API exeption with status 408
                .Handle<ApiException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                // Retry but execute some code before retrying
                .RetryAsync(RETRIES, async (exeption, retryCount) =>
                {
                    await Task.Delay(300).ConfigureAwait(false);
                })
                // Execute the command
                .ExecuteAsync(async () => await _coinDeskApiService.GetCurrentPriceV1Async())
                .ConfigureAwait(false);
        }

        public async Task<ApiResponse<BitcoinPriceIndex>> GetCurrentPriceV1Policy3Async()
        {
            var retryPolicy = Policy
                .Handle<ApiException>(ex => ex.StatusCode == HttpStatusCode.RequestTimeout)
                .Or<ApiException>(ex => ex.StatusCode > HttpStatusCode.BadRequest)
                .RetryAsync (RETRIES, async (exception, retryCount) =>
                {
                    await Task.Delay(300).ConfigureAwait(false);
                });

            var fallbackPolicy = Policy
                .Handle<Exception>()
                .FallbackAsync(async (cancelelationToken) => 
                {
                    await _coinDeskApiService.GetCurrentPriceV1Async().ConfigureAwait(false);
                });

            return await fallbackPolicy
                .WrapAsync(retryPolicy)
                .ExecuteAsync(async () => await _coinDeskApiService.GetCurrentPriceV1Async().ConfigureAwait(false))
                .ConfigureAwait(false);
        }
    }
}
