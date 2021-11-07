using APIProduct.Client;
using APIProduct.Model;
using APIProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        [HttpGet]
        public async Task<List<Products>> GetProducts()
        {

            var services = new ServiceCollection();

            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            try
            {
                return await provider.GetRequiredService<IHttpClientServiceImplementation>()
                    .Execute();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("ProductClient", config =>
            {
                config.BaseAddress = new Uri("https://fakestoreapi.com/products");
                config.Timeout = new TimeSpan(0, 0, 30);
                config.DefaultRequestHeaders.Clear();
            });

            services.AddHttpClient<ProductClient>();

            services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService>();
        }
    }
}
