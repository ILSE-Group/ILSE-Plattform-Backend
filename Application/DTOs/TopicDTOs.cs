namespace Application.DTOs
{
    public record TopicResponse(Guid Id, string Name);

    public record TopicRequest(string Name);


}