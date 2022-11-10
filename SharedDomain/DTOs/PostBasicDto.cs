namespace SharedDomain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string Title { get;}
    public string Body { get; }
    public string OwnerName { get; }

    public PostBasicDto(int id, string title, string body, string ownerName)
    {
        Id = id;
        Title = title;
        Body = body;
        OwnerName = ownerName;
    }
}