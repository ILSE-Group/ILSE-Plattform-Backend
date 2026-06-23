using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/topics")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicResponse>>> GetAll()
        {
            var topics = await _topicService.GetAllAsync();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponse>> GetById(Guid id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            if (topic == null) return NotFound();
            return Ok(topic);
        }
    }
}