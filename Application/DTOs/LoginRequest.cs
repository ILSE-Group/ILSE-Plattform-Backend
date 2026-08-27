
    public class LoginRequest
    {
        public string SecretId { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string OtpCode { get; set; } = default!;
    }