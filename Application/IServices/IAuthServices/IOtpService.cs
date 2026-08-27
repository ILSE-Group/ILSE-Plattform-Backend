using Application.DTOs;

namespace Application.IServices.IAuthServices
{
    public interface IOtpService
    {
        Task<CreateOtpResponse> CreateOtpAsync(CreateOtpRequest request, Guid callerId);
    }
}