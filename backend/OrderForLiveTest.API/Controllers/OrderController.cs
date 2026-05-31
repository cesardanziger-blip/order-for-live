using Microsoft.AspNetCore.Mvc;
using OrderForLiveTest.Application.DTOs.Requests;
using OrderForLiveTest.Application.Interfaces;

namespace OrderForLiveTest.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService service) : ControllerBase
    {
        private readonly IOrderService _service = service;

        /// <summary>
        /// Cria um novo pedido
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            await _service.CreateAsync(request);

            return Created();
        }

        /// <summary>
        /// Busca todos os pedidos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();

            return Ok(orders);
        }

        /// <summary>
        /// Busca pedido por ID
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _service.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Deleta um pedido por ID
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}