using Ecommerce.API.DTOs;
using Ecommerce.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var products = await _service.GetAllAsync();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _service.GetByIdAsync(id);
                if (product == null) return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os dados: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return BadRequest("Os dados fornecidos estão vazios!");

                var product = await _service.AddProductAsync(productDTO);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                await _service.UpdateProductAsync(productDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _service.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir produto: {ex.Message}");
            }
        }
    }
}
