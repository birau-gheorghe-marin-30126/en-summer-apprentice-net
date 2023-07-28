using Microsoft.EntityFrameworkCore;
using TMS_API.Exceptions;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public TicketCategoryRepository(TicketManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TicketCategory> GetByIdGetByIdAndDescription(int id, string description)
        {
            var ticketCategory = await _dbContext.TicketCategorys
                .Where(e => e.EventId == id && e.Description == description)
                .Include(t => t.Orders).FirstOrDefaultAsync();
            if (ticketCategory == null)
            {
                throw new EntityNotFoundException(id, nameof(TicketCategory));
            }
            return ticketCategory;
        }
    }
}
