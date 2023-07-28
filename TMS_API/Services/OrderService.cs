using AutoMapper;
using TMS_API.Models.DTO;
using TMS_API.Repositories;

namespace TMS_API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            Console.WriteLine("Hello O");
            var orders = await _orderRepository.GetAll();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderPatchDTO> UpdateOrder(OrderPatchDTO orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            var ticketCategory = await _ticketCategoryRepository.GetByIdGetByIdAndDescription((int)orderEntity.TicketCategoryId, orderPatch.Description);

            if (orderPatch.NumberOfTickets != null)
            {
                orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            }
            orderEntity.TotalPrice = orderPatch.NumberOfTickets * ticketCategory.Price;

            _orderRepository.Update(orderEntity);
            return orderPatch;
        }

        public async Task DeleteOrder(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            _orderRepository.Delete(orderEntity);
        }
    }
}
