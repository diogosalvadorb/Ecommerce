using Ecommerce.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var products = await _repository.GetAllAsync();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}
