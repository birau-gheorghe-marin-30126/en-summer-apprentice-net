using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Exceptions;
using TMS_API.Models;

namespace TMS_API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }


        /*public int Add(Event @event)
        {
            if (@event.TicketCategories != null && @event.TicketCategories.Any())
            {
                foreach (var ticketCategory in @event.TicketCategories)
                {
                    _dbContext.TicketCategories.Add(ticketCategory);
                }
            }

            _dbContext.Events.Add(@event);

            _dbContext.SaveChanges(); 

            return @event.Eventid; 
        }*/

        /*public async Task Delete(int id)
        {
            var @event = await _dbContext.Events
                .Include(e => e.TicketCategorys) 
                .Where(e => e.Eventid == id).FirstOrDefaultAsync();

            if (@event == null)
                throw new NotFoundException($"Event with ID {id} not found.");

            _dbContext.TicketCategorys.RemoveRange((TicketCategory)@event.TicketCategorys);
            _dbContext.Events.Remove(@event);
            await _dbContext.SaveChangesAsync();
        }*/

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
            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();   
        }

        /*public async Task DeleteWithRelatedEntitiesAsync(int eventId)
        {
            var @event = await _dbContext.Events.Include(e => e.TicketCategorys).FirstOrDefaultAsync(e => e.Eventid == eventId);
            if (@event == null)
                throw new NotFoundException($"Event with ID {eventId} not found.");

            _dbContext.TicketCategorys.RemoveRange((TicketCategory)@event.TicketCategorys);
            _dbContext.Events.Remove(@event);

            await _dbContext.SaveChangesAsync();
        }*/

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

    }
}
