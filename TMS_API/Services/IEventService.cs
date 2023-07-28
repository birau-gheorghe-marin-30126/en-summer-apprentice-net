using TMS_API.Models.DTO;

namespace TMS_API.Services
{
    public interface IEventService
    {
        Task<List<EventDTO>> GetAll();
        Task<EventDTO> GetById(int id);
        Task<EventPatchDTO> Patch(EventPatchDTO eventPatch);
    }
}
