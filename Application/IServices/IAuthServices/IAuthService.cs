using Application.DTOs;

namespace Application.IServices.IAuthServices
{
    public interface IAuthService
    {
        Task<SetCredentialResponse> SetCredentialsAsync(SetCredentialRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}