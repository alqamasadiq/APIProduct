using APIProduct.Controllers;
using APIProduct.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace APIProduct.UnitTest
{
    public class APIProductUnitTest
    {
        private ProductController _productController;
        public APIProductUnitTest()
        {
            _productController = new ProductController();
        }
        [Fact]
        public async Task TestProductController()
        {
            //Act  
            var data = await _productController.GetProducts();

            //Assert  
            Assert.IsType<List<Products>>(data);
        }
    }
}
