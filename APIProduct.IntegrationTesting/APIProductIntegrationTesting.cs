using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace APIProduct.IntegrationTesting
{
    public class APIProductIntegrationTesting : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        private const string requestUrl = "/api/Product/";
        public APIProductIntegrationTesting(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }
        [Fact]
        public async Task TestGetProducts()
        {
            // Act
            var response = await Client.GetAsync(requestUrl);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
