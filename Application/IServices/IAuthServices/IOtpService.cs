using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices.IAuthServices
{
    public interface IOtpService
    {
        /// <summary>
        /// Creates a new OTP + placeholder User. Called by Admin/Teacher.
        /// Returns the code and the generated username to show to the admin.
        /// </summary>
        Task<CreateOtpResponse> CreateOtpAsync(CreateOtpRequest request, Guid createdByUserId);
    }
}
