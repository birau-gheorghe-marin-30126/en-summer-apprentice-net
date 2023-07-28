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
using TMS_API.Services;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDTO>>> GetAll()
        {
            var events = await _eventService.GetAll();
            return Ok(events);
        }

        [HttpGet]
        public async Task<ActionResult<EventDTO>> GetById(int id)
        {
            var @event = await _eventService.GetById(id);
            return Ok(@event);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var patchedEvent = await _eventService.Patch(eventPatch);
            return Ok(patchedEvent);
        }
    }
}
