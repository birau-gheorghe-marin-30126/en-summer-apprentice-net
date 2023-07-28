using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMS_API.Models.DTO;
using TMS_API.Repositories;
using TMS_API.Services;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAll()
        {
            Console.WriteLine("Hello C");
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDTO>> Patch(OrderPatchDTO orderPatch)
        {
            var updatedOrderPatch = await _orderService.UpdateOrder(orderPatch);
            return Ok(updatedOrderPatch);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
