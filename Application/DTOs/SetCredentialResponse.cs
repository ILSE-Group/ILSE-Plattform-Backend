namespace Application.DTOs
{
    public class SetCredentialResponse
    {
        public string SecretId { get; set; } = default!; // einmalig im Klartext, nur für diesen Schüler
    }
}