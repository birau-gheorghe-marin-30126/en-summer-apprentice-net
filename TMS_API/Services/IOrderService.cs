using TMS_API.Models.DTO;

namespace TMS_API.Services
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAll();
        Task<OrderDTO> GetOrderById(int id);
        Task<OrderPatchDTO> UpdateOrder(OrderPatchDTO orderPatch);
        Task DeleteOrder(int id);
    }
}
