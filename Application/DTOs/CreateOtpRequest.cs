namespace Application.DTOs
{
    public class CreateOtpRequest
    {
        public Guid UserId { get; set; } // bestehender Schüler-User, für den das OTP erzeugt wird
    }
}