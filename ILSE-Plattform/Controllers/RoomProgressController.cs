using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/rooms/{roomId}/progress")]
    public class RoomProgressController : ControllerBase
    {
        private readonly IRoomProgressService _roomProgressService;

        public RoomProgressController(IRoomProgressService roomProgressService)
        {
            _roomProgressService = roomProgressService;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<RoomProgressResponse>> Start(Guid roomId, Guid userId)
        {
            var progress = await _roomProgressService.StartAsync(roomId, userId);
            return Ok(progress);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<RoomProgressResponse>> GetByRoomAndUser(Guid roomId, Guid userId)
        {
            var progress = await _roomProgressService.GetByRoomAndUserAsync(roomId, userId);
            if (progress == null) return NotFound();
            return Ok(progress);
        }
    }
}