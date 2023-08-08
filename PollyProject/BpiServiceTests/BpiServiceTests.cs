using NUnit.Framework;
using PollyProject.Services;
using PollyProject.TestSetups;
using PollyProject.Utilities;
using System.Net;

namespace PollyProject.BpiServiceTests
{
    [TestFixture]
    [Category("Bpi Regression")]
    [Author("George G")]
    public class BpiServiceTests : BaseTest
    {
        private CoinDeskApiService _cdApiService;

        [SetUp]
        public async Task SetUp()
        {
            // This Method performs before eachmethod is called

            // Initialize the ApiService with the API URL
            _cdApiService = new CoinDeskApiService(EnvironmentManager.BaseUrl);

        }


        [TestCase(
            200,
            TestName = "GET - Coin Desk Endpoint. 200 - OK")]
        public async Task GET_CoinDeskEndpoint(HttpStatusCode expectedStatus)
        {
            var response = await _cdApiService.GetCurrentPriceV1Async();

            Assert.AreEqual(
                HttpStatusCode.OK,
                response.StatusCode,
                "Http response code validation failed");

            await Console.Out.WriteLineAsync(response.Content.chartName);
        }

        [TestCase(
            200,
            TestName = "GET - Coin Desk Endpoint. Policy2 - OK")]
        public async Task GET_CoinDeskEndpointPolicy2(HttpStatusCode excpectedStatus)
        {
            var response = await _cdApiService.GetCurrentPriceV1Policy2Async();

            Assert.AreEqual(
                HttpStatusCode.OK,
                response.StatusCode,
                "Http response code validation failed");

            await Console.Out.WriteLineAsync(response.Content.disclaimer);
        }


        [TestCase(
            200,
            TestName = "GET - Coin Desk Endpoint. Policy3 - OK")]
        public async Task GET_CoinDeskEndpointPolicy3(HttpStatusCode excpectedStatus)
        {
            var response = await _cdApiService.GetCurrentPriceV1Policy3Async();

            Assert.AreEqual(
                HttpStatusCode.OK,
                response.StatusCode,
                "Http response code validation failed");

            await Console.Out.WriteLineAsync(response.Content.disclaimer);
        }
    }
}
