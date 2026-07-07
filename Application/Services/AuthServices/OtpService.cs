using Application.DTOs;
using Application.IServices.IAuthServices;
using Domain.DomainObjects;
using Domain.DomainObjects.User;
using Domain.Factories;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IUserRepositories;

namespace Application.Services.AuthServices
{
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
}
