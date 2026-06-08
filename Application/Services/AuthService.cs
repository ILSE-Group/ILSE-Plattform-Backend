using Application.DTOs;
using Application.Services;
using Domain.DomainObjects;
using Domain.DomainObjects.User;
using Domain.DomainObjects.User.UserEnums;
using Domain.Factories;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IUserRepositories;

namespace Application.Services
{
    public interface IOtpService
    {
        /// <summary>
        /// Creates a new OTP + placeholder User. Called by Admin/Teacher.
        /// Returns the code and the generated username to show to the admin.
        /// </summary>
        Task<CreateOtpResponse> CreateOtpAsync(CreateOtpRequest request, Guid createdByUserId);
    }

    public interface IAuthService
    {
        /// <summary>
        /// Validates the OTP, invalidates it, and returns a JWT.
        /// </summary>
        Task<LoginResponse> LoginWithOtpAsync(LoginRequest request);
    }


    public class OtpService : IOtpService
    {
        private readonly IOTPRepository _otpRepo;
        private readonly IUserRepository _userRepo;

        public OtpService(IOTPRepository otpRepo, IUserRepository userRepo)
        {
            _otpRepo = otpRepo;
            _userRepo = userRepo;
        }

        public async Task<CreateOtpResponse> CreateOtpAsync(CreateOtpRequest request, Guid createdByUserId)
        {
            // 1. Generate random username
            string username = UsernameFactory.GenerateRandomUsername();

            // 2. Create the user in advance (role known, XP starts at 0)
            var user = User.CreateNew(username, request.TargetRole);
            await _userRepo.AddAsync(user);

            // 3. Generate a short, readable code (e.g. "A3K-92F")
            string code = GenerateCode();
            var otp = OneTimePassword.CreateNew(code, request.TargetRole, createdByUserId, user.Id);
            await _otpRepo.AddAsync(otp);

            return new CreateOtpResponse(code, username);
        }

        private static string GenerateCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // no 0/O/1/I
            var rng = new Random();
            var part1 = new string(Enumerable.Range(0, 3).Select(_ => chars[rng.Next(chars.Length)]).ToArray());
            var part2 = new string(Enumerable.Range(0, 3).Select(_ => chars[rng.Next(chars.Length)]).ToArray());
            return $"{part1}-{part2}";
        }
    }


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