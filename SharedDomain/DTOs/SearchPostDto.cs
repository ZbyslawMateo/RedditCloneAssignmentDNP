namespace SharedDomain.DTOs;

public class SearchPostDto
{
    public string? TitleContains { get; }
    public string? AuthorName { get; }

    public SearchPostDto(string? titleContains, string? authorName)
    {
        TitleContains = titleContains;
        AuthorName = authorName;
    }
}