using Application.DTOs;
using Application.IServices.IAuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/otp")]
    [Authorize(Roles = "Teacher,Admin")] // only Teacher or Admin can create codes
    public class OtpController(IOtpService otpService) : ControllerBase
    {
        private readonly IOtpService _otpService = otpService;

        /// <summary>
        /// Admin/Teacher creates a new one-time code for a student.
        /// Returns the code and the auto-generated username to hand to the student.
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOtpRequest request)
        {
            // Read the calling user's ID from the JWT claims
            var callerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                ?? User.FindFirst("sub")?.Value;

            if (!Guid.TryParse(callerIdClaim, out var callerId))
                return Unauthorized();

            var response = await _otpService.CreateOtpAsync(request, callerId);

            // 201 Created – body contains code + username to show in the UI
            return StatusCode(201, response);
        }
    }
}