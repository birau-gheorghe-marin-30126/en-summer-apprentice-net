using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Exceptions;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        public OrderRepository(TicketManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
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
            Console.WriteLine("Hello R");
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
            if (@order == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }
            return @order;
        }

        public void Update(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }
    }
}
