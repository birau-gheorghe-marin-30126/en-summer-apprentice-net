using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <List<Order>> GetAll()
        {
            var orders = await _dbContext.Orders
                                   .Include(e => e.TicketCategory)
                                   .Include(e => e.User)
                                   .ToListAsync(); ;
            return orders;
        }

        public async Task <Order> GetById(int id)
        {
            var @order = await _dbContext.Orders
                                   .Include(e => e.TicketCategory)
                                   .Include(e => e.User)
                                   .Where(e => e.Orderid == id).FirstOrDefaultAsync();
            return @order;
        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
