using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetByIdGetByIdAndDescription(int id, string description);
    }
}
