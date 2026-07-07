using Application.DTOs;

namespace Application.IServices.IAuthServices
{
    public interface IAuthService
    {
        /// <summary>
        /// Validates the OTP, invalidates it, and returns a JWT.
        /// </summary>
        Task<LoginResponse> LoginWithOtpAsync(LoginRequest request);
    }
}
