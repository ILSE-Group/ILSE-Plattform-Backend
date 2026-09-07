using Application.DTOs;
using Application.IServices.ITopicServices;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/topics/{topicId}/rooms")] 
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomResponse>>> GetAllForTopic(Guid topicId)
        {
            var rooms = await _roomService.GetAllByTopicIdAsync(topicId);
            return Ok(rooms);
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<RoomResponse>> GetById(Guid topicId, Guid roomId)
        {
            var room = await _roomService.GetByIdAsync(roomId);
            if (room == null) return NotFound();
            return Ok(room);
        }
    }
}