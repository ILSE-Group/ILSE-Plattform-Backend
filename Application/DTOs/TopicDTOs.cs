namespace Application.DTOs
{
    public record TopicRequest(string Name);
    public record TopicResponse(Guid Id, string Name);
}