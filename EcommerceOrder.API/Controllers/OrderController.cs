using EcommerceOrder.API.DTOs;
using EcommerceOrder.API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _service.GetAllAsync();
            if (orders == null) return NotFound();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var order = await _service.GetByIdAsync(id);
                if (order == null) return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os dados: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var newOrder = await _service.AddOrderAsync(orderDTO);
                if (newOrder == null)
                    return BadRequest("Estoque insuficiente ou produto não encontrado.");

                return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao realizar Pedido: {ex.Message}");
            }
        }
    }
}
