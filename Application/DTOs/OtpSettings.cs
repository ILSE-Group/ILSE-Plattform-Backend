namespace Application.DTOs
{
    public class OtpSettings
    {
        public int ExpiryDays { get; set; } = 3;
        public int CodeLength { get; set; } = 8;
    }
}