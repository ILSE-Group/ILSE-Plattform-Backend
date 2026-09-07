using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/levels")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelResponse>>> GetAll()
        {
            var levels = await _levelService.GetAllAsync();
            return Ok(levels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LevelResponse>> GetById(Guid id)
        {
            var level = await _levelService.GetByIdAsync(id);
            if (level == null) return NotFound();
            return Ok(level);
        }
    }
}