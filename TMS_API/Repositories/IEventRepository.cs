using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAll();
        Task<Event> GetById(int id);
        void Update(Event @event);

    }
}
