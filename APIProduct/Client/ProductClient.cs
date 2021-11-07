using APIProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIProduct.Client
{
    public class ProductClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

		public ProductClient(HttpClient client)
		{
			_client = client;

			_client.BaseAddress = new Uri("https://fakestoreapi.com/products");
			_client.Timeout = new TimeSpan(0, 0, 30);
			_client.DefaultRequestHeaders.Clear();

			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task<List<Products>> GetProducts()
		{
			using (var response = await _client.GetAsync(Common.Common.BackendService, HttpCompletionOption.ResponseHeadersRead))
			{
				response.EnsureSuccessStatusCode();

				var stream = await response.Content.ReadAsStreamAsync();

				var products = await JsonSerializer.DeserializeAsync<List<Products>>(stream, _options);

				return products;
			}
		}

	}
}
