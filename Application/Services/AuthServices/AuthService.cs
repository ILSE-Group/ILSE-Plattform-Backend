using Application.DTOs;
using Application.IServices.IAuthServices;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IUserRepositories;

namespace Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IOTPRepository _otpRepo;
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenService _jwtService;

        public AuthService(IOTPRepository otpRepo, IUserRepository userRepo, IJwtTokenService jwtService)
        {
            _otpRepo = otpRepo;
            _userRepo = userRepo;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> LoginWithOtpAsync(LoginRequest request)
        {
            // 1. Find OTP
            var otp = await _otpRepo.GetByCodeAsync(request.Code.ToUpperInvariant())
                ?? throw new UnauthorizedAccessException("Invalid code.");

            if (otp.IsUsed)
                throw new UnauthorizedAccessException("This code has already been used.");

            // 2. Load the pre-created user
            var user = await _userRepo.GetByIdAsync(otp.UserId)
                ?? throw new InvalidOperationException("User not found for this code.");

            // 3. Invalidate OTP
            otp.MarkAsUsed();
            await _otpRepo.UpdateAsync(otp);

            // 4. Issue JWT
            string token = _jwtService.GenerateToken(user);

            return new LoginResponse(token, user.Username, user.Role.ToString());
        }
    }
}