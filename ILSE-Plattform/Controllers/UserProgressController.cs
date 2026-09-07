using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/progress")]
    public class UserProgressController : ControllerBase
    {
        private readonly IUserProgressService _userProgressService;

        public UserProgressController(IUserProgressService userProgressService)
        {
            _userProgressService = userProgressService;
        }

        [HttpPost]
        public async Task<ActionResult<UserProgressResponse>> Start(Guid userId)
        {
            var progress = await _userProgressService.StartAsync(userId);
            return Ok(progress);
        }

        [HttpGet]
        public async Task<ActionResult<UserProgressResponse>> GetByUserId(Guid userId)
        {
            var progress = await _userProgressService.GetByUserIdAsync(userId);
            if (progress == null) return NotFound();
            return Ok(progress);
        }
    }
}