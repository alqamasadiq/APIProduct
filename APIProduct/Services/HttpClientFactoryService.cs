using APIProduct.Client;
using APIProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIProduct.Services
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProductClient _productClient;
        private readonly JsonSerializerOptions _options;

        public HttpClientFactoryService(IHttpClientFactory httpClientFactory, ProductClient productClient)
        {
            _httpClientFactory = httpClientFactory;
            _productClient = productClient;

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task <List<Products>> Execute()
        {
            return await GetProducts(); ;
        }

        private async Task<List<Products>> GetProducts() => await _productClient.GetProducts();
    }
}
