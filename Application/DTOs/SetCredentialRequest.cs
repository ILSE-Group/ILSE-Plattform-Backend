namespace Application.DTOs
{
    public class SetCredentialRequest
    {
        public Guid UserId { get; set; }
        public string Password { get; set; } = default!;
    }
}