
    public class CreateOtpResponse
    {
        public string Code { get; set; } = default!;
        public string Username { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
    }