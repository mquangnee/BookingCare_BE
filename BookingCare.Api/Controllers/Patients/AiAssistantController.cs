using BookingCare.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingCare.Api.Controllers.Patients
{
    [Route("api/patient/ai-assistant")]
    [ApiController]
    //[Authorize(Roles = "Patient")]
    public class AiAssistantController : ControllerBase
    {
        private readonly IAiAssistantService _aiAssistantService;

        public AiAssistantController(IAiAssistantService aiAssistantService)
        {
            _aiAssistantService = aiAssistantService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var aiResponse = await _aiAssistantService.ProcessChatAsync(request.Message);
            return Ok(new { Response = aiResponse });
        }
    }

    public class ChatRequest
    {
        public string? Message { get; set; }
    }
}
