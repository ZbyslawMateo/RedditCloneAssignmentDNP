namespace SharedDomain.DTOs;

public class PostCreationDto
{
    public int OwnerId { get; }
    public string Title { get; }
    public string Body { get; }

    public PostCreationDto(int ownerId, string title, string body)
    {
        Title = title;
        OwnerId = ownerId;
        Body = body;
    }
}