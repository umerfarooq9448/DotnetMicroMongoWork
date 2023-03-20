using Customer_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_Api.Repository;

namespace Products_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepo _productRepo;

        public ProductsController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        [Route("/getAllProducts")]
        public IActionResult getAllProducts()
        {
            var products = _productRepo.getAllProducts();
            return Ok(products);
        }


        [HttpPost]
        [Route("/addProduct")]
        public IActionResult addProducts([FromBody] ProductsTable product) {

            _productRepo.addProducts(product);
            return StatusCode(200);

        }

        [HttpDelete]
        [Route("/deleteProduct/{id}")]
        public IActionResult deleteProducts(int id)
        {
            _productRepo.deleteProduct(id);
            return StatusCode(200);

        }

        [HttpPut]
        [Route("/updateProduct")]
        public IActionResult updateProduct([FromBody] ProductsTable product)
        {   
            _productRepo.updateProduct(product);
            return StatusCode(200);

        }
    }
}
