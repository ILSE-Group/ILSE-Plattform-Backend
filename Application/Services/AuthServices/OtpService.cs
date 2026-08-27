using Application.DTOs;
using Application.IServices.IAuthServices;
using Domain.DomainObjects;
using Domain.Factories;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IUserRepositories; 
using Domain.Utility;
using Microsoft.Extensions.Options;

namespace Application.Services.AuthServices
{
    public class OtpService : IOtpService
    {
        private readonly IOTPRepository _otpRepository;
        private readonly IUserRepository _userRepository;
        private readonly OtpSettings _settings;

        public OtpService(IOTPRepository otpRepository, IUserRepository userRepository, IOptions<OtpSettings> settings)
        {
            _otpRepository = otpRepository;
            _userRepository = userRepository;
            _settings = settings.Value;
        }

        public async Task<CreateOtpResponse> CreateOtpAsync(CreateOtpRequest request, Guid callerId)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId)
                ?? throw new InvalidOperationException("User not found.");

            var plainCode = OtpCodeGenerator.Generate(_settings.CodeLength);
            var codeHash = OtpHasher.Hash(plainCode);

            var otp = OneTimePassword.CreateNew(codeHash, user.UserRole, callerId, user.Id, _settings.ExpiryDays);
            await _otpRepository.AddAsync(otp);

            return new CreateOtpResponse
            {
                Code = plainCode,
                Username = user.Username,
                ExpiresAt = otp.ExpiresAt
            };
        }
    }
}