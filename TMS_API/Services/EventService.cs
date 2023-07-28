using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TMS_API.Models.DTO;
using TMS_API.Repositories;

namespace TMS_API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<EventDTO>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            var dtoEvents = _mapper.Map<List<EventDTO>>(events);
            return dtoEvents;
        }

        public async Task<EventDTO> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);
            var dtoEvent = _mapper.Map<EventDTO>(@event);
            return dtoEvent;
        }

        public async Task<EventPatchDTO> Patch(EventPatchDTO eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);

            if (!eventPatch.EventName.IsNullOrEmpty())
            {
                eventEntity.EventName = eventPatch.EventName;
            }
            if (!eventPatch.EventDescription.IsNullOrEmpty())
            {
                eventEntity.EventDescription = eventPatch.EventDescription;
            }

            _eventRepository.Update(eventEntity);
            return eventPatch;
        }
    }
}
