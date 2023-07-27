using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMS_API.Models.DTO;
using TMS_API.Repositories;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            var dtoOrders = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(dtoOrders);

        }


        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var @order = await _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var dtoOrder = _mapper.Map<OrderDTO>(@order);

            return Ok(dtoOrder);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDTO>> Patch(OrderPatchDTO orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }

            if (orderPatch.NumberOfTickets != null)
            {
                orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            }
            if (orderPatch.OrderedAt != null)
            {
                orderEntity.OrderedAt = orderPatch.OrderedAt;
            }
            if(orderPatch.TotalPrice != null)
            {
                orderEntity.TotalPrice = orderPatch.TotalPrice;
            }    
            _orderRepository.Update(orderEntity);
            return NoContent();
        }
    }
}
