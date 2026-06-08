using Domain.DomainObjects.User.UserEnums;

namespace Application.DTOs
{
    // OTP
    /// <summary>Admin/Teacher sends this to create a new OTP for a student.</summary>
    public record CreateOtpRequest(UserRole TargetRole);

    /// <summary>Returned to the Admin/Teacher after OTP creation.</summary>
    public record CreateOtpResponse(string Code, string Username);

    // Auth
    /// <summary>Student sends this to exchange their OTP for a JWT.</summary>
    public record LoginRequest(string Code);

    /// <summary>Returned to the student after successful login.</summary>
    public record LoginResponse(string Token, string Username, string Role);
}