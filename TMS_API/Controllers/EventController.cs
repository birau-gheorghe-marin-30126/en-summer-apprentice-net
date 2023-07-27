using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using TMS_API.Exceptions;
using TMS_API.Models;
using TMS_API.Models.DTO;
using TMS_API.Repositories;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper) 
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDTO>>> GetAll()
        {
            var events = await _eventRepository.GetAll();

            var dtoEvents = _mapper.Map<List<EventDTO>>(events);

            return Ok(dtoEvents);

        }


        [HttpGet]
        public async Task<ActionResult<EventDTO>> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);

            if(@event == null)
            {
                return NotFound();
            }

            var dtoEvent = _mapper.Map<EventDTO>(@event);

            return Ok(dtoEvent);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if(eventEntity == null)
            {
                return NotFound();  
            }

            if (!eventPatch.EventName.IsNullOrEmpty())
            {
                eventEntity.EventName = eventPatch.EventName;
            }
            if (!eventPatch.EventDescription.IsNullOrEmpty())
            {
                eventEntity.EventDescription = eventPatch.EventDescription;
            }
            _eventRepository.Update(eventEntity);
            return NoContent();
        }


        /*[HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _eventRepository.DeleteWithRelatedEntitiesAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }*/

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
