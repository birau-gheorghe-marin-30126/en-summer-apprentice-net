using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Exceptions;
using TMS_API.Models;

namespace TMS_API.Repositories { 

    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public EventRepository(TicketManagementSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Event>> GetAll()
        {
            var events = await _dbContext.Events
                                   .Include(e => e.Venue)
                                   .Include(e => e.EventType)
                                   .ToListAsync();
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events
                                   .Include(e => e.Venue)
                                   .Include(e => e.EventType)
                                   .Where(e => e.Eventid == id).FirstOrDefaultAsync();
            if (@event == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
