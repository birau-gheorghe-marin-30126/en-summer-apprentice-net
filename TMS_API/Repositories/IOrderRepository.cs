using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface IOrderRepository
    {
        Task <List<Order>> GetAll();
        Task <Order> GetById(int id);
        int Add(Order @order);
        void Update(Order @order);
        void Delete(Order @order);
    }
}
