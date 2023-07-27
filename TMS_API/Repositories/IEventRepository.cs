using TMS_API.Models;

namespace TMS_API.Repositories
{
    public interface IEventRepository
    {
        Task <List<Event>> GetAll();
        Task <Event> GetById(int id);
        int Add(Event @event);
        void Update(Event @event);
        void Delete(Event @event);
        //Task Delete(int id);
        //Task DeleteWithRelatedEntitiesAsync(int id);
    }
}
